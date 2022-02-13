using Lazy.Captcha.Core;
using Lazy.Captcha.Core.Generator;
using Lazy.Captcha.Core.Generator.Code;
using Lazy.Captcha.Core.Generator.Image.Option;
using SixLabors.ImageSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache().AddCaptcha(option =>
{
    option.CaptchaType = CaptchaType.WORD; // ��֤������
    option.CodeLength = 4; // ��֤�볤��, Ҫ����CaptchaType���ú�
    option.ExpiryTime = TimeSpan.FromSeconds(30); // ��֤�����ʱ��
    option.IgnoreCase = true; // �Ƚ�ʱ�Ƿ���Դ�Сд
    option.ImageOption.Animation = false; // �Ƿ����ö���
    
    option.ImageOption.Width = 130; // ��֤����
    option.ImageOption.Height = 48; // ��֤��߶�
    option.ImageOption.BackgroundColor = SixLabors.ImageSharp.Color.White; // ��֤�뱳��ɫ
    
    option.ImageOption.BubbleCount = 2; // ��������
    option.ImageOption.BubbleMinRadius = 5; // ������С�뾶
    option.ImageOption.BubbleMaxRadius = 15; // �������뾶
    option.ImageOption.BubbleThickness = 1; // ���ݱ��غ��

    option.ImageOption.InterferenceLineCount = 2; // ����������

    option.ImageOption.FontSize = 28; // �����С
    option.ImageOption.FontFamily = DefaultFontFamilys.Instance.Scandal; // ���壬����ʹ��kaiti�������ַ��ɸ���ϲ�����ã����ܲ���ת�ַ�����ֻ��Ʋ������������
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
