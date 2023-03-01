//Maria Waleska Marinho de Oliveira 
// mwmarinhodeolive1749gconestogac.on.ca
namespace Assigment2
{
    public partial class Assignment2 : Form
    {
        public Assignment2()
        {
            InitializeComponent();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            // initialize Erro msg
            string erroMsg = "";
            
            //Get the costumer name and check the input
            string CostumerName = txtCostumerName.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(CostumerName))
            {
                erroMsg += "Please input your name!\n";
               
            }
            //Get the costumer email and check the input
            string CostumerEmail = txtEmail.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(CostumerEmail))
            {

            }
            else
            { //Call the method to check is is valid 
                if (!ValidationHelper.IsValidEmail(ref CostumerEmail))
                {
                    erroMsg += "The email is invalid! \n";

                }

            }
            // Get the addres and check it.
            string Address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(CostumerEmail))
            {
                if (string.IsNullOrEmpty(Address))
                {
                    erroMsg += "Address is required if email is not provided!\n";

                }

            }
          // Get the City and check it
            string City = txtCity.Text.Trim();

            if (string.IsNullOrEmpty(CostumerEmail))
            {
                if (string.IsNullOrEmpty(City))
                {
                    erroMsg += "City is required if email is not provided!\n";
                }

            }

            // Get the Province and check it
            string Province = txtProvince.Text.Trim();
            if (string.IsNullOrEmpty(CostumerEmail))
            {
                if (string.IsNullOrEmpty(Province))
                {
                    erroMsg += "Province is required if email is not provided!\n";

                }
                else // Call the method 
                {
                    if (!ValidationHelper.IsValidProvinceCode(ref Province))
                    {
                        erroMsg += "You must choose a Canadian Province\n";
                    }

                }

            }

            //Get the postal Code and check 
            string PostalCode = txtPostalCode.Text.Trim();

            if (string.IsNullOrEmpty(CostumerEmail))
            {
                if (string.IsNullOrEmpty(PostalCode))
                {
                    erroMsg += "Postal Code is required if email is not provided!\n";

                }
                else
                {
                    if (!ValidationHelper.IsValidPostalCode(ref PostalCode))
                    {
                        erroMsg += "A valid postal code in the format A2A 3B3 is required.\n";
                    }
                }

            }

          //Get the Phone and Home Number  and check it  
            string phoneNumber = txtCellPhone.Text.Trim();
            string homeNumber = txtHomePhone.Text.Trim();

            lblErroMsg.ForeColor = Color.Black;
           

            if (string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(homeNumber))
            {
                lblErroMsg.Text = erroMsg += "At least one of home or cell phone numbers are required\n";
            }
            else if (!string.IsNullOrEmpty(phoneNumber))
            {
                if (!ValidationHelper.IsValidPhoneNumber(ref phoneNumber))
                {
                    erroMsg += "The phone number is not in the correct format : 123-123-1234\n ";
                }
            }
            else if (!ValidationHelper.IsValidPhoneNumber(ref homeNumber))
            {
                erroMsg += "The phone number is not in the correct format : 123-123-1234\n ";

            }
            else 
            {
                
            }


            // Get the make and Model 
            string MakemModel = txtMakeModel.Text.Trim();
            if (string.IsNullOrEmpty(MakemModel))
            {
                erroMsg += "Make & model is required \n ";

            }
            //Get and check the year 
            string yearString = txtYear.Text;
            if (!string.IsNullOrEmpty(yearString))
            {
                int year = Convert.ToInt32(yearString);

                if (year < 1900 || year > 2023)
                {
                    erroMsg += "Year most be between 1990 to 2023\n ";
                }
            }

            // Get an Check the choosen data
            if (!BookCalendar.Checked || BookCalendar.Value.Day < DateTime.Now.Day)
            {
                erroMsg += "The date can not be in the past!\n ";
            }
            // Call the method to Capitalize the output
            string modyfyName = ValidationHelper.Capitalize(CostumerName);
            string modyfyAddress = ValidationHelper.Capitalize(Address);
            string modyfyMakeModel = ValidationHelper.Capitalize(MakemModel);
            string modyfyCity = ValidationHelper.Capitalize(City);
            
            //Output
            if (erroMsg == "")
            {
                //add the dashs in the phone number 
                string number = "";
                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {

                    bool CheckSpacePhoneNumber = phoneNumber.Contains("-");
                    if (CheckSpacePhoneNumber == false)
                    {

                        phoneNumber = phoneNumber.Insert(3, "-");
                        phoneNumber = phoneNumber.Insert(7, "-");


                    }
                    number = phoneNumber;

                }
                if (!string.IsNullOrWhiteSpace(homeNumber))
                {
                    bool CheckSpaceHomeNumber = homeNumber.Contains("-");
                    if (CheckSpaceHomeNumber == false)
                    {

                        homeNumber = homeNumber.Insert(3, "-");
                        homeNumber = homeNumber.Insert(7, "-");


                    }
                    number = homeNumber;

                }
                



               
               

                if (string.IsNullOrEmpty(CostumerEmail))
                {

                    lblErroMsg.Text =

                                       "Appointment booked successfully! Thank you\n\n" +
                                       $"Name:  {modyfyName}\n" +
                                       $"Address:   {modyfyAddress} \n" +
                                       $"Make And Model:    {modyfyMakeModel} \n" +
                                       $"City:  {modyfyCity} \n" +
                                       $"Province:  {Province} \n" +
                                       $"Postal Code:   {PostalCode} \n" +
                                       $"Cellphone Number:  {number}\n" +
                                      $" At : {BookCalendar.Value.Day}-{BookCalendar.Value.Month}-{BookCalendar.Value.Year}"

                                       ;
                }
                else if (!string.IsNullOrEmpty(CostumerEmail))
                {
                    lblErroMsg.Text =

                                       "Appointment booked successfully! Thank you\n\n" +
                                       $"Name: {modyfyName}\n" +
                                       $"Make And Model:    {modyfyMakeModel} \n" +
                                       $"Cellphone Number:  {number} \n" +
                                       $"Email: {CostumerEmail} \n \n" +
                                       $" At : {BookCalendar.Value.Day}-{BookCalendar.Value.Month}-{BookCalendar.Value.Year}"
                                       ;

                }

            }
            else
            {
                lblErroMsg.ForeColor = Color.Red;
                lblErroMsg.Text = erroMsg;
            }


        }
        // Close the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();    

        }
        // Pre Fill information 
        private void btnPreFill_Click(object sender, EventArgs e)
        {
           
            txtCostumerName.Text = "MARIA WALESKA ";
            txtAddress.Text = "310 King Street";
            txtCity.Text = "TORONTO";
            txtProvince.Text = "on";
            txtPostalCode.Text = "n2n 2k2";
            txtCellPhone.Text = "123-123-1234";
            txtMakeModel.Text = " Kia- Ford ";
            txtYear.Text = "2015";

        }
        //Reset information 
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCostumerName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtPostalCode.Text = "";
            txtCellPhone.Text = "";
            txtHomePhone.Text = "";
           txtMakeModel.Text = "";
            txtYear.Text = "";
            txtEmail.Text = "";

            lblErroMsg.Text = "";
        }
    }

}