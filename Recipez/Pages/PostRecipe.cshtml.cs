using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.IngredientCategoryModule.Interface;
using Repository.RecipeModule.Interface;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipez.Pages
{
    public class PostRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe recipe { get; set; }        
        [BindProperty]
        public string listStepID { get; set; }
        private List<IngredientCategory> ingredientCategories { get; set; }
        public Account user { get; set; }
        
        private readonly RecipezService recipezService;
        public PostRecipeModel()
        {            
            recipezService = new RecipezService();
            ingredientCategories = recipezService.ingredientCategoryService.GetAll().ToList();
        }        
        public void OnGet()
        {                        
            // load combobox data
            ViewData["IngredientCategoryId"] = new SelectList(ingredientCategories, "IngredientCategoryId", "IngredientCategoryName");
            // get user data from session            
            
            // check role, redirect to page
        }
        public IActionResult OnPost()
        {
            Boolean checkValidate=true;
            
            // get list ingredients, recipe detail from form
            string listIngredientID = Request.Form["listIngredientId"];
            //
            List<Ingredient> ingredients=new List<Ingredient>();
            List<RecipeDetail> recipeDetail = new List<RecipeDetail>();
            //
            string[] ingredientID=listIngredientID.Split(",");
            foreach(var id in ingredientID)
            {                
                RecipeDetail detail = new RecipeDetail();
                Ingredient ingredient = new Ingredient();
                //get data
                string IngredientName = Request.Form["ingredientName" + id];
                int IngredientCategoryId = int.Parse(Request.Form["ingredientCategory" + id]);
                string quantity= Request.Form["quantity" + id];
                //validate
                if (IngredientName == null||IngredientName.Trim().Equals(""))
                {
                    ViewData["IngredientNameError"] = "Ingredient Name cannot be empty";
                    checkValidate=false;
                }
                if (quantity == null||quantity.Trim().Equals(""))
                {
                    ViewData["QuantityError"] = "Quantity cannot be empty";
                    checkValidate = false;
                }
                //set data
                ingredient.IngredientCategoryId= IngredientCategoryId;
                ingredient.IngredientName= IngredientName;
                detail.Ingredient = ingredient;                
                detail.Quantity= quantity;
                //add to list
                recipeDetail.Add(detail);
                ingredients.Add(ingredient);
            }
            //get list step from form
            string listStepID = Request.Form["listStepId"];
            List<Step> steps=new List<Step>();
            string[] stepID = listStepID.Split(",");
            int stepCount = 1;
            foreach (var id in stepID)
            {
                Step step = new Step();
                //get data
                string stepName = Request.Form["stepName"+id];
                string description = Request.Form["description" + id];
                //validate
                if (stepName == null||stepName.Trim().Equals(""))
                {
                    ViewData["StepNameError"] = "Step Name cannot be empty";
                    checkValidate = false;
                }
                if (description == null||description.Trim().Equals(""))
                {
                    ViewData["DescriptionError"] = "Description cannot be empty";
                    checkValidate = false;
                }
                //set data
                step.Description = description;
                step.StepName=stepName;
                step.Index=stepCount;
                stepCount++;
                //add to list
                steps.Add(step);

            }            
            recipe.NumberOfStep = stepCount;
            //validate name
            if (recipe.RecipeName == null || recipe.RecipeName.Trim().Equals(""))
            {
                ViewData["RecipeNameError"] = "Recipe Name cannot be empty";
                checkValidate = false;
            }
            if(checkValidate == false)
            {
                ViewData["IngredientCategoryId"] = new SelectList(ingredientCategories, "IngredientCategoryId", "IngredientCategoryName");
                return Page();
            }
            //save ingredients to db, return list ingredients for id in recipe detail table
            List<Ingredient> savedIngredient = new List<Ingredient>();
            foreach (Ingredient ing in ingredients)
            {
                Ingredient check=recipezService.ingredientService.GetIngredientByName(ing.IngredientName);
                if (check != null)
                {
                    savedIngredient.Add(check);
                }
                else
                {                    
                    Ingredient ingredient = recipezService.ingredientService.AddIngredient(ing);
                    savedIngredient.Add(ingredient);
                }
            }
            //add ingredient id to list recipe detail           
            foreach (var ingredient in savedIngredient)
            {
                foreach(var detail in recipeDetail)
                {
                    if (detail.Ingredient.IngredientName.Equals(ingredient.IngredientName))
                    {
                        detail.IngredientId=ingredient.IngredientId;
                    }
                }
            }
            //set recipe status to active
            recipe.Status = 1;                               
            //recipe.RecipeId= recipezService.recipeService.AddNewPost(recipe, user.AccountId.ToString(), recipeDetail);
            recipe.RecipeId = recipezService.recipeService.AddNewPost(recipe, "1", recipeDetail);
            //save steps to db
            foreach (var step in steps)
            {
                step.RecipeId = recipe.RecipeId;
                recipezService.stepService.AddNewStep(step);
            }
            return RedirectToPage("./Home");
        }
    }
}
