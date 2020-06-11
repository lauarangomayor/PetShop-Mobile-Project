using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Configuration
{
    public class EndPoints
    {

        public static readonly string SERVER_URL = "https://3.20.51.47:5001/";
        public static readonly string GET_ALL_CATEGORIES = "Category/all";
        public static readonly string CREATE_CATEGORY = "Category/create";
        public static readonly string GET_ALL_STATESPRODUCT = "StatesProduct/all";
        public static readonly string CREATE_PRODUCT = "Product/create";
        public static readonly string GET_ALL_PRODUCTS = "Product/all";
        public static readonly string GET_APPOINTMENTRECORDS = "appointmentrecord/getAppointmentRecordByPetId/";
        public static readonly string REGISTER_VET = "Veterinarian/registerVeterinarian";
        public static readonly string VALIDATE_CLIENT = "Client/getClientByEmailAndPassword/";
        public static readonly string REGISTER_CLIENT = "client/registerClient";
        public static readonly string DELETE_PET = "pet/delete/";


    }
}