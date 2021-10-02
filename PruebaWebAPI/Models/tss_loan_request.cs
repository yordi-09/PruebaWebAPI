using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebAPI.Models
{
    public class tss_loan_request
    {
        public int sub_id { get; set; }
        public string bank_account_type { get; set; }
        public string bank_name { get; set; }
        public string client_url_root { get; set; }
        public int customer_id { get; set; }
        public int employer_length_months { get; set; }
        public string employer_name { get; set; }
        public string ext_work { get; set; }
        public string home_city { get; set; }
        public string home_state { get; set; }
        public string home_street { get; set; }
        public string home_zip { get; set; }
        public int income_date1_d { get; set; }
        public int income_date1_m { get; set; }
        public int income_date1_y { get; set; }
        public int income_date2_d { get; set; }
        public int income_date2_m { get; set; }
        public int income_date2_y { get; set; }
        //public DateTime Nacimiento { get; set; }
        public string income_frequency { get; set; }
        public double income_amount { get; set; }
        public string income_type { get; set; }
        public double loan_amount_desired { get; set; }
        public string military { get; set; }
        public string name_first { get; set; }
        public string name_last { get; set; }
        public string name_middle { get; set; }
        public string name_title { get; set; }
        public string phone_home { get; set; }
        public string phone_cell { get; set; }
        public int date_dob_d { get; set; }
        public int date_dob_m { get; set; }
        public int date_dob_y { get; set; }
        public int residence_length_months { get; set; }
        public string residence_type { get; set; }
        public int ssn_part_1 { get; set; }
        public int ssn_part_2 { get; set; }
        public int ssn_part_3 { get; set; }
        public int state_id_number { get; set; }
        public string bank_check_number { get; set; }
        public string state_issued_id { get; set; }
    }
}