using Lazy.Captcha.Core;
using Lazy.Captcha.Core.Generator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCacheCaptcha(builder.Configuration, option =>
 {
     option.CaptchaType = CaptchaType.WORD; // ��֤������
     option.CodeLength = 4; // ��֤�볤��, Ҫ����CaptchaType���ú�
     option.ExpirySeconds = 60; // ��֤�����ʱ��
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

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();