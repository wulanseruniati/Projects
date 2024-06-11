class Program {
    static void Main() {
        using (Northwind db = new())
        {
            bool isActive = db.Database.CanConnect();
            System.Console.WriteLine(isActive);
            List<Category> categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                System.Console.WriteLine(category.CategoryName);
            }
        }
    }
}