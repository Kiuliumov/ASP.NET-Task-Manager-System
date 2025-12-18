using CantinaManager.Models;
using CantinaManager.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace CantinaManager.Services.Verification
{
    public class UserVerificationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public UserVerificationService(UserManager<User> userManager, IEmailService emailService, IConfiguration config)
        {
            _userManager = userManager;
            _emailService = emailService;
            _config = config;
        }

        public async Task SendVerificationEmailAsync(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = HttpUtility.UrlEncode(token);

            var frontendUrl = _config["Frontend:Url"] ?? "https://localhost:3000";
            var verificationLink = $"{frontendUrl}/verify-email?userId={user.Id}&token={encodedToken}";

            var subject = "Verify your email";
            var message = $@"
                <h3>Hello {user.FullName},</h3>
                <p>Thank you for registering. Please verify your email by clicking the link below:</p>
                <a href='{verificationLink}'>Verify Email</a>
                <p>If you did not register, please ignore this email.</p>
            ";

            await _emailService.SendEmailAsync(user.Email!, subject, message);
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var decodedToken = HttpUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            return result.Succeeded;
        }
    }
}
