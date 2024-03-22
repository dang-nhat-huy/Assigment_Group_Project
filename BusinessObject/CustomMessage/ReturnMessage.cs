using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.CustomMessage
{
    public class ReturnMessage
    {
        public const string UPDATE_STATUS_SUCCESS = "Update Status Success!";
        public const string UPDATE_STATUS_FAILED = "Update Status Fail!";
        public const string UPDATE_SUCCESS = "Update Item Success!";
        public const string DELETE_SUCCESS = "Delete Item Success!";
        public const string ADD_SUCCESS = "Add New Item Success!";
        public const string UPDATE_FAIL = "Update Item Fail!";
        public const string DELETE_FAIL = "Delete Item Fail!";
        public const string ADD_FAIL = "Add New Item Fail!";
        public const string SUCCESS = "Success";
        public const string FAIL = "Fail";
        public const string EMPTY_LIST = "Empty List";
        public const string NULL_DATA = "Data Is Null";

        // Common error messages
        public const string NOT_FOUND = "Not Found";
        public const string BAD_REQUEST = "Bad Request";

        // Specific error messages for different entities
        public const string CATEGORY_NOT_FOUND = "Category " + NOT_FOUND;
        public const string FEEDBACK_NOT_FOUND = "Feedback " + NOT_FOUND;
        public const string MENU_NOT_FOUND = "Menu " + NOT_FOUND;
        public const string ORDER_NOT_FOUND = "Order " + NOT_FOUND;
        public const string SERVICE_NOT_FOUND = "Service " + NOT_FOUND;
        public const string TASK_NOT_FOUND = "Task " + NOT_FOUND;
        public const string VOUCHER_NOT_FOUND = "Voucher " + NOT_FOUND;
        public const string USER_NOT_FOUND = "User " + NOT_FOUND;
        public const string ORDER_DETAIL_NOT_FOUND = "Order Detail " + NOT_FOUND;

        // Error for duplicate important data
        public const string DUPLICATE_EMAIL = "Duplicate Email";
        public const string DUPLICATE_NAME = "Duplicate Name";

        // Error For Login And Signup
        public const string WRONG_LOGIN_INFO = "Wrong Email Or Password!";
        public const string LOGIN_SUCCESS = "Login Success!";
        public const string LOGIN_FAIL = "Login Fail!";
        public const string SIGNUP_SUCCESS = "Sign Up Success!";
        public const string SIGNUP_FAIL = "Sign Up Fail!";
        public const string BANNED = "Your Account Is Banned!";
        public const string FAILED_MATCH_PASSWORD = "Confirm Password Is Not Matched Password";
    }
}
