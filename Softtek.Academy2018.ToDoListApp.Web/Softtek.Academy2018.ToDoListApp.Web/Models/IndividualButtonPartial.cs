using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }

        public string Action { get; set; }

        public string GlyphIcon { get; set; }

        public string Text { get; set; }

        public int CosaId { get; set; }

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                param.Append($"{CosaId}");

                return param.ToString();
            }

        }
    }
}