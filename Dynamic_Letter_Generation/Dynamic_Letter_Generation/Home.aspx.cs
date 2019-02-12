using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Words.NET;

namespace Dynamic_Letter_Generation
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        public void ReplaceTextAndLogo()
        {

            String courseName = txtCourseName.Text;
            String studentName =  txtName.Text;
            String address = txtAddress.Text;
            String email = txtEmail.Text;
            String dateIssued = DateTime.Now.ToString("dd-MMM-yyyy");
            String salutationName = txtName.Text;

            
            String LetterPath = Server.MapPath(".") + "\\base_letters";
            String SavePath = "C:\\";

            String baseLetterName = "OfferLetter";

            // Load a document
            using (DocX document = DocX.Load(LetterPath + "\\" + baseLetterName + ".docx"))
            {
                // Get the regular bookmark from the document and replace its Text.
                document.AddHeaders();
                document.DifferentFirstPage = true;

                var dateIssuedBookmark = document.Bookmarks["dateissued"];
                var courseNameBookmark = document.Bookmarks["coursename"];
                var studentNameBookmark = document.Bookmarks["studentname"];
                var addressBookmark = document.Bookmarks["address"];
                var emailBookmark = document.Bookmarks["email"];
                var salutationNameBookmark = document.Bookmarks["salutationname"];
                var headerImageBookmark = document.Headers.First.InsertBookmark("HeaderImage");
                var headerNameBookmark = document.Headers.First.InsertBookmark("headername");



                if (dateIssuedBookmark != null)
                {
                    dateIssuedBookmark.SetText(dateIssued);
                }

                if (courseNameBookmark != null)
                {
                    courseNameBookmark.SetText(courseName);
                }

                if (studentNameBookmark != null)
                {
                    studentNameBookmark.SetText(studentName);
                }

                if (addressBookmark != null)
                {
                    addressBookmark.SetText(address);
                }

                if (emailBookmark != null)
                {
                    emailBookmark.SetText(email);
                }

                if (salutationNameBookmark != null)
                {
                    salutationNameBookmark.SetText(salutationName);
                }

                


                string imageName = "logo";
                String ImageFullPath = Util.GetFullImagePath(imageName);

                System.IO.FileInfo fileImage = new System.IO.FileInfo(ImageFullPath);

                if (fileImage.Exists) // Try to set Logo Only when image file exists
                {

                    Xceed.Words.NET.Image logoImage = document.AddImage(ImageFullPath);

                    Xceed.Words.NET.Picture picture = logoImage.CreatePicture();

                    if (headerImageBookmark != null)
                    {
                        headerImageBookmark.AppendPicture(picture);

                    }

                }


                if (headerNameBookmark != null)
                {

                    headerImageBookmark.InsertText("Quality is our excellence");

                }



                #region SaveAndOpen
                document.SaveAs(SavePath + "\\" + baseLetterName + "_" + studentName + ".docx");


                System.IO.FileInfo file = new System.IO.FileInfo(SavePath + "\\" + baseLetterName + "_" + studentName + ".docx"); //TODO evt sæt i variabel, sysconst


                // Write Excel fil to screen
                if (file.Exists)
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.WriteFile(file.FullName);
                    HttpContext.Current.Response.End();
                }
                #endregion SaveAndOpen

            }
        }

        protected void btnLetterGenerate_Click(object sender, EventArgs e)
        {
            ReplaceTextAndLogo();
        }
    }
}