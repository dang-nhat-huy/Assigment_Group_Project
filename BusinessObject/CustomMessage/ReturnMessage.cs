using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.CustomMessage
{
    public class ReturnMessage
    {
        public const string UPDATE_SUCCESS = "Update Item Success!";
        public const string DELETE_SUCCESS = "Delete Item Success!";
        public const string ADD_SUCCESS = "Add New Item Success!";
        public const string UPDATE_FAIL = "Update Item Fail!";
        public const string DELETE_FAIL = "Delete Item Fail!";
        public const string ADD_FAIL = "Add New Item Fail!";
        public const string SUCCESS = "Success";
        public const string FAIL = "Fail";
        public const string EMPTY_LIST = "Empty List";
        // Common error messages
        public const string NOT_FOUND = "Not Found";

        // Specific error messages for different entities
        public const string CATEGORY_NOT_FOUND = "Category " + NOT_FOUND;
        public const string FEEDBACK_NOT_FOUND = "Feedback " + NOT_FOUND;
        public const string MENU_NOT_FOUND = "Menu " + NOT_FOUND;
        public const string ORDER_NOT_FOUND = "Order " + NOT_FOUND;
        public const string SERVICE_NOT_FOUND = "Service " + NOT_FOUND;
        public const string TASK_NOT_FOUND = "Task " + NOT_FOUND;
        public const string VOUCHER_NOT_FOUND = "Voucher " + NOT_FOUND;
        public const string CHANGE_STATUS_FAIL = "Change Status " + FAIL;
    }
}
