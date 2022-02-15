using Lazy.Captcha.Core;
using Lazy.Captcha.Core.Generator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRedisCacheCaptcha(builder.Configuration);

/*

// ȫ������
builder.Services.AddMemoryCacheCaptcha(builder.Configuration, option =>
{
    option.CaptchaType = CaptchaType.WORD; // ��֤������
    option.CodeLength = 6; // ��֤�볤��, Ҫ����CaptchaType���ú�
    option.ExpirySeconds = 30; // ��֤�����ʱ��
    option.IgnoreCase = true; // �Ƚ�ʱ�Ƿ���Դ�Сд
    option.ImageOption.Animation = true; // �Ƿ����ö���

    option.ImageOption.Width = 150; // ��֤����
    option.ImageOption.Height = 50; // ��֤��߶�
    option.ImageOption.BackgroundColor = SixLabors.ImageSharp.Color.White; // ��֤�뱳��ɫ

    option.ImageOption.BubbleCount = 2; // ��������
    option.ImageOption.BubbleMinRadius = 5; // ������С�뾶
    option.ImageOption.BubbleMaxRadius = 15; // �������뾶
    option.ImageOption.BubbleThickness = 1; // ���ݱ��غ��

    option.ImageOption.InterferenceLineCount = 2; // ����������

    option.ImageOption.FontSize = 36; // �����С
    option.ImageOption.FontFamily = DefaultFontFamilys.Instance.Scandal; // ���壬����ʹ��kaiti�������ַ��ɸ���ϲ�����ã����ܲ���ת�ַ�����ֻ��Ʋ������������
});

*/

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();