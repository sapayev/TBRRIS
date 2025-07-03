# Task 2: SQL Запрос для связи продуктов и категорий

## Условие задачи

В базе данных MS SQL Server есть таблицы **продуктов** и **категорий**. Один продукт может относиться к нескольким категориям, и одна категория может содержать несколько продуктов.

**Задача**:  
Написать SQL-запрос для получения всех пар «Имя продукта – Имя категории».  
Если у продукта **нет категорий**, его имя всё равно должно быть выведено.

---

## Структура таблиц и связи

Для реализации связи **многие ко многим**, используется промежуточная таблица `ProductCategories`.

### Таблицы:

- `Products` (`ProductID`, `Name`)
- `Categories` (`CategoryID`, `Name`)
- `ProductCategories` (`ProductID`, `CategoryID`)

---

## Диаграмма

![Diagram](/digram.png)

---

## Сам SQL-запрос

```sql
-- Таблица продуктов
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name TEXT
);

INSERT INTO Products VALUES
    (1, 'Phone'),
    (2, 'Laptop'),
    (3, 'Mouse');

-- Таблица категорий
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    Name TEXT
);

INSERT INTO Categories VALUES
    (1, 'Electronic'),
    (2, 'Accessories'),
    (3, 'Gift');

CREATE TABLE ProductCategories (
    ProductID INT,
    CategoryID INT,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

INSERT INTO ProductCategories VALUES
    (1, 1), 
    (1, 3),
    (2, 2);
    
SELECT 
    Products.Name AS ProductName,
    Categories.Name AS CategoryName
FROM 
    Products
LEFT JOIN 
    ProductCategories ON Products.ProductID = ProductCategories.ProductID
LEFT JOIN 
    Categories ON ProductCategories.CategoryID = Categories.CategoryID;

---
```
## Результат

![Result](/result.png)
