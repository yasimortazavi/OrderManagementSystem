// Features/Customers/Validators/CreateCustomerValidator.cs
using FluentValidation;
using CustomerService.Features.Customers.Commands.CreateCustomer;

namespace CustomerService.Features.Customers.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("نام الزامی است")
                .MaximumLength(50).WithMessage("نام نمی‌تواند بیش از 50 کاراکتر باشد");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("نام خانوادگی الزامی است")
                .MaximumLength(50).WithMessage("نام خانوادگی نمی‌تواند بیش از 50 کاراکتر باشد");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("ایمیل الزامی است")
                .EmailAddress().WithMessage("فرمت ایمیل نامعتبر است")
                .MustAsync(BeUniqueEmail).WithMessage("این ایمیل قبلا ثبت شده است");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("شماره تلفن الزامی است")
                .Matches(@"^09\d{9}$").WithMessage("شماره تلفن همراه معتبر نیست");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken ct)
        {
            // پیاده‌سازی بررسی یکتا بودن ایمیل
            return await Task.FromResult(true);
        }
    }
}