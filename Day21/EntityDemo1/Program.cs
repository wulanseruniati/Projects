using EntityFramework;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using (Northwind db = new())
        {
            bool status = db.Database.CanConnect();
            System.Console.WriteLine(status);
            List<Category> categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                System.Console.WriteLine($"Category id: {category.CategoryId} | Category name: {category.CategoryName} | Category description: {category.Description}");
            }
            Category? category1 = db.Categories.Find(4);
            Category? category2 = db.Categories.Where(c => c.CategoryId == 1).FirstOrDefault();
            Category? categorySeafood = db.Categories.Where(c => c.CategoryName == "Seafood").FirstOrDefault();
            int categoryTest = db.Categories.Find(4).CategoryId;
            System.Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"Category id: {category1.CategoryId} | Category name: {category1.CategoryName} | Category description: {category1.Description}");
            System.Console.WriteLine($"Category id: {category2.CategoryId} | Category name: {category2.CategoryName} | Category description: {category2.Description}");
            System.Console.WriteLine(categoryTest);
            System.Console.WriteLine($"Category id: {categorySeafood.CategoryId} | Category name: {categorySeafood.CategoryName} | Category description: {categorySeafood.Description}");
            //create
            /*
            Category category3 = new()
            {
                CategoryName = "Sumanto",
                Description = "Eat humans"
            };
            db.Categories.Add(category3);
            db.SaveChanges();
            */
            //Category? sumanto = db.Categories.Where(c => c.CategoryName == "Sumanto").FirstOrDefault();
            //System.Console.WriteLine($"Category id: {sumanto.CategoryId} | Category name: {sumanto.CategoryName} | Category description: {sumanto.Description}");
            //update
            /*Category categoryToUpdate = db.Categories.FirstOrDefault(c => c.CategoryId == 9);
            //alternative (LinQ):
            //Category categoryToUpdate = db.Categories.Where(c => c.CategoryId == 9).FirstOrDefault();
            if (categoryToUpdate != null)
            {
                // Update the CategoryName
                categoryToUpdate.CategoryName = "Yanto";
                categoryToUpdate.Description = "Eat fruits";

                // Save the changes to the database
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
            */
            //delete
            //Category categoryToDelete = db.Categories.FirstOrDefault(c => c.CategoryId == 9);
            //alternative (LinQ):
            Product productToDelete = db.Products.Where(c => c.ProductId == 77).FirstOrDefault();
            if (productToDelete != null)
            {
                 db.Products.Remove(productToDelete);
                 db.SaveChanges();
                //db.Database.ExecuteSqlRaw("DELETE FROM Categories WHERE CategoryId = 9");
                //error:
                //Unhandled exception. Microsoft.Data.Sqlite.SqliteException (0x80004005): SQLite Error 19: 'FOREIGN KEY constraint failed'.
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}