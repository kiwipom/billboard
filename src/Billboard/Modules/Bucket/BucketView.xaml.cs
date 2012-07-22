using System;
using System.Collections.Generic;
using Billboard.Data;
using Windows.UI.Xaml.Controls;

namespace Billboard
{
    public sealed partial class BucketView
    {
        public BucketView()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var group = SampleDataSource.GetGroup((int)navigationParameter);
            this.DefaultViewModel["Group"] = group;
            this.DefaultViewModel["Items"] = group.Tasks;
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
    }
}
