using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.CustomMessage;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;

namespace Assigment_Group_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public FeedbackController(IFeedbackService feedbackService, IMapper mapper, IUserService userService)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet("GetAll", Name = "Get All Feedbacks")]
        public IActionResult GetAllFeedbacks(int? page = 1, int? quantity = 10)
        {
            try
            {
                var list = _feedbackService.GetAll(page, quantity);
                if (!list.Any())
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get/{id}", Name = "Get Feedback By ID")]
        public IActionResult GetCategoryById([FromRoute] long id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                if (feedback == null)
                {
                    return NotFound(ReturnMessage.FEEDBACK_NOT_FOUND);
                }
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetByUser/{userId}", Name = "Get Feedback By User ID")]
        public IActionResult GetCategoryByUserId([FromRoute] long userId)
        {
            try
            {
                var feedbacks = _feedbackService.GetAll().Where(x => x.UserId == userId);
                if (!feedbacks.Any())
                {
                    return NotFound(ReturnMessage.EMPTY_LIST);
                }
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add", Name = "Add New Feedback")]
        public IActionResult AddFeedback(FeedbackRequestVM request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }
                var user = _userService.GetById((long) request.UserId!);
                if (user == null)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                Feedback newFeedback = _mapper.Map<Feedback>(request);
                _feedbackService.Add(newFeedback);
                _feedbackService.Save();

                return Ok(ReturnMessage.ADD_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update/{id}", Name = "Update Existing Feedback")]
        public IActionResult UpdateFeedback([FromRoute] long id, string fbContent)
        {
            try
            {
                if (string.IsNullOrEmpty(fbContent))
                {
                    return BadRequest(ReturnMessage.NULL_DATA);
                }
                if (fbContent != null && fbContent.Trim().Length > 50)
                {
                    return BadRequest(ReturnMessage.BAD_REQUEST);
                }

                var feedback = _feedbackService.GetById(id);
                if (feedback == null)
                {
                    return NotFound(ReturnMessage.FEEDBACK_NOT_FOUND);
                }

                feedback.FbContent = fbContent ?? feedback.FbContent;
                _feedbackService.Update(feedback);
                _feedbackService.Save();

                return Ok(ReturnMessage.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}", Name = "Delete Feedback")]
        public IActionResult DeleteFeedback([FromRoute] long id)
        {
            try
            {
                var deleteCategory = _feedbackService.GetById(id);
                if (deleteCategory == null)
                {
                    return NotFound(ReturnMessage.FEEDBACK_NOT_FOUND);
                }

                _feedbackService.Delete(deleteCategory);
                _feedbackService.Save();

                return Ok(ReturnMessage.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
