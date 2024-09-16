using Append.Blazor.Printing;
using Blazored.LocalStorage;
using Blazored.Toast;
using BlazorStrap;
using Microsoft.AspNetCore.Http.Features;
using RapidNRIMs;
using RapidNRIMs.Data;
using RapidNRIMs.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddBootstrapCss();
builder.Services.AddSingleton<ImageService>();
builder.Services.AddSingleton<PDFResizer>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IRecordEventTypeService, RecordEventTypeService>();
builder.Services.AddScoped<IRecordEventDistrictService, RecordEventDistrictService>();
builder.Services.AddScoped<IRecordEventProvinceService, RecordEventProvinceService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IMasterData, MasterData>();
builder.Services.AddScoped<IMasterDataInstrument, MasterDataInstrument>();
builder.Services.AddScoped<IMasterDataPhase2, MasterDataPhase2>();
builder.Services.AddScoped<IMasterDataRecord, MasterDataRecord>();
builder.Services.AddScoped<IMasterDataInventory, MasterDataInventory>();
//builder.Services.AddScoped<IInstrumentSearchService, InstrumentSearchService>();
builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IInstrumentBrandService, InstrumentBrandService>();
builder.Services.AddScoped<IInstrumentTypeService, InstrumentTypeService>();
builder.Services.AddScoped<IInstrumentModelService, InstrumentModelService>();
builder.Services.AddScoped<IInstrumentLocationService, InstrumentLocationService>();
builder.Services.AddScoped<IInstrumentAgencyService, InstrumentAgencyService>();
builder.Services.AddScoped<IInstrumentCalibrationService, InstrumentCalibrationService>();
builder.Services.AddScoped<IInstrumentMaintenanceService, InstrumentMaintenanceService>();
builder.Services.AddScoped<IInstrumentMaintenanceTypeService, InstrumentMaintenanceTypeService>();
builder.Services.AddScoped<IInstrumentDiscardService, InstrumentDiscardService>();
builder.Services.AddScoped<IInstrumentCheckOutService, InstrumentCheckOutService>();
builder.Services.AddScoped<IInstrumentCheckInService, InstrumentCheckInService>();
builder.Services.AddScoped<IRadiationSourceService, RadiationSourceService>();
builder.Services.AddScoped<IInstrumentDiscardService, InstrumentDiscardService>();
builder.Services.AddScoped<IRadiationSourceTypeService, RadiationSourceTypeService>();
builder.Services.AddScoped<IRecordEventService, RecordEventService>();
builder.Services.AddScoped<IPrintingService, PrintingService>();
builder.Services.AddScoped<AppData, AppData>();
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = long.MaxValue;
    x.MultipartHeadersLengthLimit = int.MaxValue;
});
builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
{
    options.DetailedErrors = true;
});

builder.Services.AddBlazoredToast();
//builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
