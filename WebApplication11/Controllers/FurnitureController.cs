using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class FurnitureController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=FurnitureStore;Integrated Security=true;";


        public ActionResult Index()
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            return View(new FurnitureViewModel
            {
                FurnitureItems = db.GetAll()
            });
        }

        public ActionResult ShowAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Furniture item)
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            db.Add(item);
            return Redirect("/furniture/index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            db.Delete(id);
            return Redirect("/furniture/index");
        }

        public ActionResult Edit(int id)
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            Furniture furnitureItem = db.GetById(id);
            if(furnitureItem == null)
            {
                return Redirect("/furniture/index");
            }
            return View(new EditFurnitureViewModel
            {
                FurnitureItem = furnitureItem
            });
        }

        [HttpPost]
        public ActionResult Edit(Furniture furniture)
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            db.Update(furniture);
            return Redirect("/furniture/index");
        }
    }

    //Create a page that displays a list of People (or whatever interests you).
    //On top of the page, have a link that says "Add Person". When this link
    //is clicked, the user should be taken to a page that has a form that 
    //has textboxes for firstname/lastname/age (or whatever thing you're doing).
    //Beneath that, there should be a submit button. When the button is clicked,
    //the person should get added to the database, and the user should be redirected
    //back to the list of all the people.


    //Second exercise:

    //Add a column to your table called "Delete". In each row of the table, there
    //should be a delete button, that when clicked, will delete that person from the
    //database, and redirect the user back to the page that shows a list of all people.
    //The way to achieve this is to embed each Delete button in a form that posts
    //to an Action on your controller that will delete that person. Inside that form,
    //also have a hidden input with the id of that person. Then, in your controller,
    //take that id in as a parameter, delete that person, and then redirect back to
    //the list page.

    //<input type="hidden" name="id" value="some id" />
}