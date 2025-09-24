// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
//serviceCollection.AddSingleton<DocumentRepository>();
//serviceCollection.AddTransient<DocumentRepository>();
serviceCollection.AddScoped<DocumentRepository>();
serviceCollection.AddScoped<PartRepository>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var scope1 = serviceProvider.CreateScope();
var repository = scope1.ServiceProvider.GetRequiredService<DocumentRepository>();
var repository2 = scope1.ServiceProvider.GetRequiredService<DocumentRepository>();

var scope2 = serviceProvider.CreateScope();
var repository3 = scope2.ServiceProvider.GetRequiredService<DocumentRepository>();
var repository4 = scope2.ServiceProvider.GetRequiredService<DocumentRepository>();

Console.WriteLine("Hello, World!");
return;

public class DocumentRepository
{
   public DocumentRepository(PartRepository partRepository)
   {
      
   }
}

public class PartRepository()
{
   
}

/*
Конструкторское бюро проектирование автомобилей

   Car(Автомобиль) - средство передвижения собранное по чертежу
   
   Test(Тест) - комплекс мероприятий направленный на проверку какой-то концепции
   
   Blueprint(Чертеж) - документ содержащий описание устройства автомобиля
   
   Проект(Project) - комплекс действий направленный на создание автомобиля
*/