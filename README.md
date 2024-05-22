# Разработка приложения продуктового магазина (C#)
![1](https://github.com/serega23467/WPFAppMagazine/assets/114952677/2f30372e-7a40-40fc-801d-aac544615851)

интерфейс приложения, справа товары на складе

![2](https://github.com/serega23467/WPFAppMagazine/assets/114952677/090d386b-dd93-4dc2-a381-d33bab2544b2)

активация кнопки при существующем штрихкоде

![3](https://github.com/serega23467/WPFAppMagazine/assets/114952677/c8f235c4-4052-4619-957c-5f197b8584ee)

сумма скидки

![4](https://github.com/serega23467/WPFAppMagazine/assets/114952677/cbbc7645-4cc3-47b5-ae34-f8173fbcd5c1)
чек

![5](https://github.com/serega23467/WPFAppMagazine/assets/114952677/a126a7ef-d56b-42a8-8b11-603e5a10a4dd)

ошибка при пробитии товара из-за отсутствия на складе

![6](https://github.com/serega23467/WPFAppMagazine/assets/114952677/a834b5ba-e82a-45a9-b3dd-82832137e292)

файл с логами

## Функциональность

1. **Просмотр товаров со склада**: Возможность видеть количество продуктов на складе.
2. **Пробитие товаров по штрихкоду**: Пробитие товара по штрихкоду из 13 символов, более 1 одинакового товара добавить таким образом нельзя.
3. **Расчет суммы**: Сумма для оплаты расчитывается автоматически.
4. **Вывод чека**: При нажатии кнопки создаётся чек с информацией о товарах и сумме.
5. **Логирование**: Все нажатия логируются в файл в проекте.


## Технические детали

- **Разработано на**: WPF
- **База данных**: SQLite с использованием Entity Framework
- **Тесты**: Unit тесты модуля dll MSTest
- **Подключение к dll**: Функционал из написанной библиотеки dll ProductMagazine

  ## Создание классов ChemicalElement и Product для связи с БД

``` C#
using System.ComponentModel.DataAnnotations;
namespace ProductMagazine
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public bool HasDiscount { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public string Brand { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Product(){}
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMagazine;
namespace WPFAppMagazine
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Warehouse> Warehouse { get; set; } = null!;
        public DbSet<Receipt> Receipts { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MagazineDB.db");
        }
    }
}

namespace ProductMagazine
{
    public class ProductData : Product
    {
        public int Count { get; set; }
    }
}

ProductData добавляет необходимое для интерфейса и расчетов свойство Count, так как в таблице Product БД подобного поля нет, из-за чего в Product оно быть не может.
```
  ## Код создания таблиц SQLite 

``` SQLite
CREATE TABLE "Products" (
	"Id"	INTEGER NOT NULL,
	"Price"	REAL NOT NULL,
	"Discount"	REAL NOT NULL,
	"HasDiscount"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL UNIQUE,
	"BarCode"	TEXT NOT NULL UNIQUE,
	"Brand"	TEXT NOT NULL,
	"ExpirationDate"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
)

CREATE TABLE Receipts
(
	Id	INTEGER NOT NULL UNIQUE,
	DateR	TEXT NOT NULL,
	SumR	REAL NOT NULL,
	ProductId	INTEGER NOT NULL,
	PRIMARY KEY(Id)
	FOREIGN KEY(ProductId) REFERENCES Products(Id)
)

CREATE TABLE Warehouse
(
	Id	INTEGER NOT NULL UNIQUE,
	ProductId	INTEGER NOT NULL,
	ProductCount	INTEGER NOT NULL,
	PRIMARY KEY(Id AUTOINCREMENT),
	FOREIGN KEY(ProductId) REFERENCES Products(Id)
)

Products - продукты, Receipts - сохраняющиеся данные с каждой покупки, Warehouse - склад
```

## Автор программы

### Сергей А.
