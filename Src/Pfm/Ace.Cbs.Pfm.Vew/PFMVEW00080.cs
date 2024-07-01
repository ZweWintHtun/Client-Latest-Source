using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class PFMVEW00080 : BaseForm, IPFMVEW00080
    {
        byte[] myPhoto { get; set; }
        string myFormName { get; set; }

        public PFMVEW00080()
        {
            InitializeComponent();
        }
        public PFMVEW00080(byte[] photo,string fName)
        {
            InitializeComponent();
            myPhoto = photo;
            myFormName = fName;
        }
        #region Presenter/Controller

        /// <summary>
        /// CustomerIdController 
        /// </summary>     

        private IPFMCTL00080 controller;
        public IPFMCTL00080 Controller
        {
            set
            {
                this.controller = value;
                //controller.CustomerIdView = this;
            }
            get
            {
                return this.controller;
            }
        }

        private void PFMVEW00080_Load(object sender, EventArgs e)
        {
            this.FormName = myFormName;
            picPhoto.BackgroundImage = CXClientGlobal.GetImage(myPhoto);
            picPhoto.BackgroundImageLayout = ImageLayout.Stretch;

            //picPhoto.Image = resizeImage(CXClientGlobal.GetImage(myPhoto), new Size(50, 50));
            //using (FileStream fs = new FileStream(imagePath, FileMode.Open))
            //{
            //    return new Bitmap(fs);
            //}
            //picPhoto.Image = new Bitmap(myPhoto);
        }
        #endregion
        
        #region Helper Method
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
            
        }
        #endregion
    }
}
