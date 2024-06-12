class Program {
    static void Main() {
        //READ ALL
        using (Northwind db = new())
        {
            //test connection
            bool isActive = db.Database.CanConnect();
            System.Console.WriteLine(isActive);
            //get data from table categories (to list)
            List<Category> categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                System.Console.WriteLine($"Name: {category.CategoryName}. Description: {category.Description}");
            }
        }
        //READ FILTER
        System.Console.WriteLine("================READ FILTER==================");
        using (Northwind db = new())
        {
            string filter = "Seafood";
            Category? category = db.Categories.Where(data => data.CategoryName == filter).FirstOrDefault();
            System.Console.WriteLine((category is not null) ? $"Seafood's description is {category.Description}" : "Not Found");
        }
        
        //ALL Chang
        using (Northwind db = new())
        {
            string filter = "Chang";
            IQueryable<Product>? products = db.Products.Where(data => data.ProductName == filter); 
            foreach (var product in products)
            {
                System.Console.WriteLine($"Chang's product id is {product.ProductID}");
            }
        }
        //CREATE
        /*using (Northwind db = new()) //buka koneksi ke database
        {
            Category category = new();
            category.CategoryName = "Drinks";
            category.Description = "Soft drinks, Poisons";
            db.Categories.Add(category);
            db.SaveChanges();
        }*/

        //ADD RANGE
        /*using (Northwind db = new()) //buka koneksi ke database
        {
            Category category1 = new();
            category1.CategoryName = "Cleaning Utilities";
            category1.Description = "Dustbins, Brooms";
            Category category2 = new();
            category2.CategoryName = "Cooking Utilities";
            category2.Description = "Stoves";
            db.Categories.AddRange(category1,category2);
            db.SaveChanges();
        }*/

        //UPDATE
        /*using (Northwind db = new())
        {
            Category? category = db.Categories.Find(9); //by id
            //Category? category = db.Categories.Where(data => data.CategoryName == "Fruits").FirstOrDefault();
            if (category != null)
            {
                // Update the CategoryDescription
                category.Description = "Apples, Cherries, Oranges";

                // Save the changes to the database
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }*/

        //DELETE
        using (Northwind db = new())
        {
            OrderDetail? orderDetail = db.OrderDetails
                                .FirstOrDefault(od => od.ProductID == 77 && od.OrderId == 11077);
            if (orderDetail != null)
            {
                // Delete the category
                db.OrderDetails.Remove(orderDetail);

                // Save the changes to the database
                db.SaveChanges();
                Console.WriteLine("Order Detail deleted successfully.");
            }
            else
            {
                Console.WriteLine("Order detail not found.");
            }
        }
    }
}