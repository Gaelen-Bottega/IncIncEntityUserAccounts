// PieceworkerModel.cs
// Author: Gaelen Rhoads & Kyle Chapman
// Created: December 6, 2021
// Modified: December 17, 2021
// Description: This file contains the read/write properties for the Pieceworker and we write our validation here.
// For lab 6 we also write our pay model here for both types of workers.

using System;
using System.ComponentModel.DataAnnotations;

namespace IncIncEntityUserAccounts.Models
{
    public class PieceworkerModel
    {
        /// <summary>
        /// ID needed for identification in the Entity Framework
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The read/write property for the workers First Name with "not null" validation
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The read/write property for the workers Last Name with "not null" validation
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Message read/write property with range validation
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have some amount of messages")]
        [Display(Name = "Messages")]
        [Range(1, 15000, ErrorMessage = "The amount of messages must be between 1 and 15,000")]
        public int Messages { get; set; }

        /// <summary>
        /// True or false based on if a worker is senior or not
        /// </summary>
        public bool IsSenior { get; set; }

        /// <summary>
        /// This calculates a workers pay based on their pay rate.
        /// </summary>
        /// <returns></returns>
        public decimal GetPay()
        {
            // Constants
            // for range
            const int TwelveFortyNine = 1249;
            const int TwentyFourNinetyNine = 2499;
            const int ThirtySevenFortyNine = 3749;
            const int FourtyNineNinetyNine = 4999;
            
            // For normal workers
            const double PointZeroTwoFiveCents = 0.025;
            const double PointZeroThree = 0.03;
            const double PointZeroThreeFive = 0.035;
            const double PointZeroFourOne = 0.041;
            const double PointZeroFourEight = 0.048;

            // for senior workers
            const double PointZeroOneEightCents = 0.018;
            const double PointZeroTwoOneCents = 0.021;
            const double PointZeroTwoFourCents = 0.024;
            const double PointZeroTwoSevenCents = 0.027;
            const double ThreeCents = 0.03;
            const double TwoHundredSeventy = 270.00;

            // The workers pay for a return
            decimal pay;

            // If the our worker is senior, they have different pay
            if (IsSenior)
            {
                if (Messages <= TwelveFortyNine)
                {
                    pay = (decimal)(PointZeroOneEightCents * Messages);
                }
                else if (Messages > TwelveFortyNine && Messages <= TwentyFourNinetyNine)
                {
                    pay = (decimal)(PointZeroTwoOneCents * Messages);
                }
                else if (Messages > TwentyFourNinetyNine && Messages <= ThirtySevenFortyNine)
                {
                    pay = (decimal)(PointZeroTwoFourCents * Messages);
                }
                else if (Messages > ThirtySevenFortyNine && Messages <= FourtyNineNinetyNine)
                {
                    pay = (decimal)(PointZeroTwoSevenCents * Messages);
                }
                else // employee sent over 5000 messages
                {
                    pay = (decimal)(ThreeCents * Messages);
                }

                // Add base pay of $270.00
                pay += (decimal)TwoHundredSeventy;

                // Round employeePay after the pay is set to the nearest cent.
                pay = Math.Round(pay, 2);

                return pay;
            }

            // Else they have the normal pay
            else
            {
                if (Messages <= TwelveFortyNine)
                {
                    pay = (decimal)(PointZeroTwoFiveCents * Messages); // 0.025 per msg
                }
                else if (Messages > TwelveFortyNine && Messages <= TwentyFourNinetyNine)
                {
                    pay = (decimal)(PointZeroThree * Messages); // 0.03 per msg
                }
                else if (Messages > TwentyFourNinetyNine && Messages <= ThirtySevenFortyNine)
                {
                    pay = (decimal)(PointZeroThreeFive * Messages); // 0.035 per msg
                }
                else if (Messages > ThirtySevenFortyNine && Messages <= FourtyNineNinetyNine)
                {
                    pay = (decimal)(PointZeroFourOne * Messages); // 0.041 per msg
                }
                else // employee sent over 5000 messages
                {
                    pay = (decimal)(PointZeroFourEight * Messages); // 0.048 per msg
                }

                // Round pay after the pay is set to the nearest cent.
                pay = Math.Round(pay, 2);
                return pay;
            }
        }
    }
}
