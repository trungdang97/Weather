using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Data;

namespace Weather.CMS
{
    public partial class NewsForm : System.Web.UI.Page
    {
        public class Filter
        {
            public string FilterText { get; set; } = "";
            public Guid? NewsCategoryId { get; set; }
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 10;
            public Guid? UserId { get; set; }
            public DateTime? FromDate { get; set; }
            public DateTime? ToDate { get; set; }
            public bool IsCMS { get; set; } = false;
        }

        public class News
        {
            public Guid NewsId { get; set; }
            public string Name { get; set; }
            public Guid NewsCategoryId { get; set; }
            public string NewsCategoryName { get; set; }
            public string Location { get; set; }
            public string Writer { get; set; }
            public Guid CreatedByUserId { get; set; }
            public DateTime? CreatedOnDate { get; set; }
            public string Introduction { get; set; }
            public string Body { get; set; }
            public bool? ApproveStatus { get; set; }
            public string Thumbnail { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User_Id"] == null)
            {
                Response.Redirect("~/Login/Index.aspx");
            }

            var rights = (List<string>)Session["User_RightsCode"];
            if (!rights.Contains("VIETTIN"))
            {
                Response.Redirect("~/Default.aspx");
            }
            using (var db = new cms_VKTTVEntities())
            {
                var category = db.cms_NewsCategory.ToList();
                foreach (var c in category)
                {
                    ListCategory.Items.Add(new ListItem()
                    {
                        Text = c.Name,
                        Value = c.NewsCategoryId.ToString()
                    });
                    ListCategory2.Items.Add(new ListItem()
                    {
                        Text = c.Name,
                        Value = c.NewsCategoryId.ToString()
                    });
                    OuterListCategory.Items.Add(new ListItem()
                    {
                        Text = c.Name,
                        Value = c.NewsCategoryId.ToString()
                    });
                }

            }
            if (!this.IsPostBack)
            {
                var filter = new Filter();
                //GetData(filter);

            }
        }

        void GetData(Filter filter)
        {

        }

        protected void SaveBtn_click(object sender, EventArgs e)
        {

        }
    }
}