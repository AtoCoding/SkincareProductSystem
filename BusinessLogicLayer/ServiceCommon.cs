using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public class ServiceCommon
    {
        public static SkincareProduct CloneObject(SkincareProduct product)
        {
            return new()
            {
                SkincareProductId = product.SkincareProductId,
                Name = product.Name,
                Description = product.Description,
                Capacity = product.Capacity,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity,
                Image = product.Image,
                IsAvailable = product.IsAvailable,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Username = product.Username,
                Brand = product.Brand,
                Category = product.Category,
            };
        }

        public static void ProcessImage(List<SkincareProduct> products)
        {
            string projectDirectory = AppContext.BaseDirectory;
            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
            imageFolder = Path.GetFullPath(imageFolder);

            foreach (var product in products)
            {
                product.Image = Path.Combine(imageFolder, product.Image);
            }
        }
    }
}
