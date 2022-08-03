using HtmlAgilityPack;
using System.Text;
using WebApp.Common.ViewModels;

namespace WebApp.Parser
{
    public class Parser
    {
        public List<ProductModel> GetProductModel()
        {
            string html = "https://en.wikipedia.org/wiki/Tea";
            HtmlWeb web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };

            HtmlDocument document = web.Load(html);
            HtmlNodeCollection ProductModelElements = document.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul[1]/li");
            
            List<ProductModel> productModelList = new List<ProductModel>();

            if (ProductModelElements != null)
            {
                foreach (HtmlNode productModelString in ProductModelElements)
                {
                    ProductModel productModel = new ProductModel();
                    string outputProductModelString = productModelString.InnerText;
                    string[] parseProductModelString = outputProductModelString.Split(':');
                    productModel.Name = parseProductModelString[0];
                    productModel.Description = parseProductModelString[1];
                    productModelList.Add(productModel);
                }
            }
            return productModelList;
        }
    }
}