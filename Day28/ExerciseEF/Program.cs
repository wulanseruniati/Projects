class Program
{
    static void Main()
    {
        //READ ALL
        using (MasterItem db = new())
        {
            //test connection
            bool isActive = db.Database.CanConnect();
            if(!isActive)
            {
                //early return
                throw new Exception("Database can't connect");   
            }
            System.Console.WriteLine("The connection is active? " + isActive);
            List<Item> items = db.Items.ToList();
            foreach (var item in items)
            {
                System.Console.WriteLine($"Name: {item.ItemName}. Description: {item.Description}");
            }
            //coba LinQ select
            List<string> components = db.Components.Select(com => com.ComponentName).Distinct().ToList();
            foreach (var component in components)
            {
                System.Console.WriteLine("Component name is : " + component);
            }
        }
        //READ FILTER
        System.Console.WriteLine("================READ FILTER==================");
        using (MasterItem db = new())
        {
            //get data from table categories (to list)
            Component? component = db.Components.Find(1);
            System.Console.WriteLine((component != null) ? $"Name: {component.ComponentName}. Description: {component.ComponentDesc}" : "Not Found");
        }

        /*using (MasterItem db = new()) //buka koneksi ke database
        {
            Item item = new();
            item.ItemName = "Aldora Necklace";
            item.Description = "Necklace with aldora chains";
            db.Items.Add(item);
            db.SaveChanges();
        }
        using (MasterItem db = new()) //buka koneksi ke database
        {
            Component component = new();
            component.ComponentName = "Aldora Chain";
            component.ComponentDesc = "Chain with skin like crafts";
            component.ItemId = db.Items.Where(data => data.ItemName == "Aldora Necklace").FirstOrDefault().ItemId;
            // Save the changes to the database
            if (db.Items.Where(data => data.ItemName == "Aldora Necklace").FirstOrDefault() != null)
            {
                db.Components.Add(component);
                db.SaveChanges();
            }
        }*/

        /*
        //delete
        using (MasterItem db = new())
        {
            // Convert string representation of Guid to Guid object
            Guid itemId = new Guid("4B9B5262-F47D-42BA-9914-52D5E61DCC97");

            // Find the item with the specified primary key
            Item? item = db.Items.FirstOrDefault(i => i.ItemId == itemId);

            if (item != null)
            {
                // Delete the item
                db.Items.Remove(item);

                // Save the changes to the database
                db.SaveChanges();
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }*/

        /*
        //update
        using (MasterItem db = new())
        {
            Component? component = db.Components.Find(1); //by id
            if (component != null)
            {
                // Update the Desc
                component.ComponentDesc = "A chain driven by snake-like motives";

                // Save the changes to the database
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }*/
        //demo related
        /*using (MasterItem db = new()) //buka koneksi ke database
        {
            Item item = new();
            item.ItemName = "Alexandra Necklace";
            item.Description = "Necklace with alexandra chains";
            db.Items.Add(item);
            db.SaveChanges();
            System.Console.WriteLine("Alexandra necklace saved successfully");
        }
        /*
        //insert component
        using (MasterItem db = new()) //buka koneksi ke database
        {
            Component component = new();
            component.ComponentName = "Alexandra Chain";
            component.ComponentDesc = "Chain with simple motives";
            component.ItemId = db.Items.Where(data => data.ItemName == "Alexandra Necklace").FirstOrDefault().ItemId;
            // Save the changes to the database
            if (db.Items.Where(data => data.ItemName == "Alexandra Necklace").FirstOrDefault() != null)
            {
                db.Components.Add(component);
                db.SaveChanges();
                System.Console.WriteLine("Alexandra chain saved successfully");
            }
            else {
                System.Console.WriteLine("Failed to save alexandra chain");
            }
        }
        */
    }
}