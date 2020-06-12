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
        public static readonly string CREATE_ORDER = "Order/create";
        public static readonly string GET_ALL_STATESPRODUCT = "StatesProduct/all";
        public static readonly string CREATE_PRODUCT = "Product/create";
        public static readonly string GET_ALL_PRODUCTS = "Product/all";
        public static readonly string GET_PRODUCTS_BY_CATEGORY = "Product/getProductsByCategoryId/";
        public static readonly string GET_APPOINTMENTRECORDS = "appointmentrecord/getAppointmentRecordByPetId/";
        public static readonly string REGISTER_VET = "Veterinarian/registerVeterinarian";
        public static readonly string VALIDATE_USER = "User/validateUserByEmailAndPasswordAndType/";
        public static readonly string REGISTER_CLIENT = "client/registerClient";
        public static readonly string DELETE_PET = "pet/delete/";
        public static readonly string GET_PRODUCTS_OF_CHART = "Product/getProductsByListId";
        public static readonly string CREATE_PET = "Pet/create";
        public static readonly string GET_ALL_SPECIES = "Specie/all";
        public static readonly string UPDATE_PRODUCT = "Product/update/";
        public static readonly string UPDATE_PET = "Pet/update/";
        public static readonly string GET_PETS_BY_CLIENT = "Pet/getPetsByClientId/";
        public static readonly string GET_USER_BY_CLIENT = "User/getUserByIdClient/";
        public static readonly string GET_ORDERS_BY_CLIENT = "Order/getOrdersByClientId/";
        public static readonly string GET_AVAILABLE_VETS = "Veterinarian/getVeterinariansAvailables/";
        public static readonly string CREATE_APPOINTMENT = "Appointments/create";



    }
}