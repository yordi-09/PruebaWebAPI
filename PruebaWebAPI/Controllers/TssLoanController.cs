using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TssLoanController : ControllerBase
    {
        [HttpGet("tss_loan_request")]
        public IActionResult Get(string RawXML)
        {
            //Instancia a Clase en carpeta de utilidades con objetivo de deserializar el xml a entidad correspondiente
            Serializer ser = new Serializer();
            tss_loan_request tss_loan = ser.Deserialize<tss_loan_request>(@RawXML);

            DateTime date_birth = DateTime.Parse(string.Format("{0}/{1}/{2}", tss_loan.date_dob_m, tss_loan.date_dob_d, tss_loan.date_dob_y));
            List<string> not_allowed_home_state = new List<string> { "CA", "FL", "NY", "GA", "NC" };
            List<string> allowed_income_frequency = new List<string> { "Weekly", "Biweekly", "Monthly", "Twice" };
            double total_income_amount = tss_loan.income_amount;
            double percent_income_amount = 2000 * 0.15;

            if (date_birth >= DateTime.Now.AddYears(-18))
            {
                return BadRequest(new { message = "El XML no cumple con el formato válido, la persona es menor a 18 años." });
            }
            if (!(tss_loan.employer_length_months > 12))
            {
                return BadRequest(new { message = "El XML no cumple con el formato válido, employer_length_months debe ser mayor a 12." });
            }
            if (tss_loan.loan_amount_desired < 200)
            {
                return BadRequest(new { message = "El XML no cumple con el formato válido, loan_amount_desired no puede ser menor a 200." });
            }
            if (tss_loan.loan_amount_desired > 500)
            {
                return BadRequest(new { message = "El XML no cumple con el formato válido, loan_amount_desired no puede ser mayor a 500." });
            }
            if (tss_loan.home_state.Length != 2)
            {
                return BadRequest(new { message = "El XML no cumple con el formato válido, home_state debe tener largo de 2 caracteres." });
            }
            if (not_allowed_home_state.Contains(tss_loan.home_state))
            {
                return BadRequest(new { message = $"El XML no cumple con el formato válido, el valor {tss_loan.home_state} no es valido para el campo home_state." });
            }
            if (!allowed_income_frequency.Contains(tss_loan.income_frequency, StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new { message = $"El XML no cumple con el formato válido, el valor {tss_loan.income_frequency} no es valido para el campo income_frequency." });
            }
            if (tss_loan.income_frequency.ToLower() == "Weekly".ToLower())
            {
                total_income_amount *= 4;
            }
            if (tss_loan.income_frequency.ToLower() == "Biweekly".ToLower() || tss_loan.income_frequency.ToLower() == "Biweekly".ToLower())
            {
                total_income_amount *= 2;
            }
            if (total_income_amount < percent_income_amount || total_income_amount > 2000)
            {
                return BadRequest(new { message = $"El XML no cumple con el formato válido, el salario mensual que es {total_income_amount} debe estar entre un rango de {percent_income_amount} y " + 2000 +"." });
            }

            return Ok(new { message = $"El XML ID: {tss_loan.customer_id}, fue aceptado con el nombre {tss_loan.name_first} {tss_loan.name_last}" });
        }
    }
}
