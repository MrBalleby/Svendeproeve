using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenSystems.Model
{
    public class User
    {
        public string? userPrincipalName {get; set;}
        public string? displayName {get; set;}
        public string? surname {get; set;}
        public string? mail {get; set;}
        public string? givenName {get; set;}
        public string? id {get; set;}
        public string? userType {get; set;}
        public string? jobTitle {get; set;}
        public string? department {get; set;}
        public string? accountEnabled {get; set;}
        public string? usageLocation {get; set;}
        public string? streetAddress {get; set;}
        public string? state {get; set;}
        public string? country {get; set;}
        public string? officeLocation {get; set;}
        public string? city {get; set;}
        public string? postalCode {get; set;}
        public string? telephoneNumber {get; set;}
        public string? mobilePhone {get; set;}
        public string? alternateEmailAddress {get; set;}
        public string? ageGroup {get; set;}
        public string? consentProvidedForMinor {get; set;}
        public string? legalAgeGroupClassification {get; set;}
        public string? companyName {get; set;}
        public string? creationType {get; set;}
        public string? directorySynced {get; set;}
        public string? invitationState {get; set;}
        public string? identityIssuer {get; set;}
        public string? createdDateTime {get; set;}
        
        public static User FromCSV(string csvLine)
        {
            string[] values = csvLine.Split(',');
            try
            {

                User user = new()
                {
                    userPrincipalName = values[0],
                    displayName = values[1],
                    surname = values[2],
                    mail = values[3],
                    givenName = values[4],
                    id = values[5],
                    userType = values[6],
                    jobTitle = values[7],
                    department = values[8],
                    accountEnabled = values[9],
                    usageLocation = values[10],
                    streetAddress = values[11],
                    state = values[12],
                    country = values[13],
                    officeLocation = values[14],
                    city = values[15],
                    postalCode = values[16],
                    telephoneNumber = values[17],
                    mobilePhone = values[18],
                    alternateEmailAddress = values[19],
                    ageGroup = values[20],
                    consentProvidedForMinor = values[21],
                    legalAgeGroupClassification = values[22],
                    companyName = values[23],
                    creationType = values[24],
                    directorySynced = values[25],
                    invitationState = values[26],
                    identityIssuer = values[27],
                    createdDateTime = values[28]
                };
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}
