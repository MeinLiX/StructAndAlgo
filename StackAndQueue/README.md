# Задачі 2
</br>
## Структура
- Постанова задачі
- **Виклик** функції(цитата з коду) 
- **Результат** програми.  
</br>
</br>

## Задача 1 
 Дано рядок символів, що містить дужки різних видів (круглі, фігурні, квадратні). Перевірте правильність розставлення в  ньому круглих дужок, будь-яких дужок.

```csharp
new Question1().Init("Exemple(text([<]>))");
```
Результат:
> ```Transmitted string is correct.```
---
<br/>

```csharp
new Question1().Init("Exemple)(text([<]>))");
```
Результат:
> ```String isn't correct!```
---
<br/>

## Задача 2 
 Дана послідовність ненульових цілих чисел. Ознакою кінця послідовності є число 0. Знайдіть серед них перший найбільший (найменший)  по модулю від’ємний елемент. Якщо такого елемента немає, то виведіть повідомлення про це.

```csharp
new Question2().Init(new List<int> { -3, -30, 2, 6, 5, -10, 23, 0 });
```
Результат: 
>``` MAXbyABS:{pos:1,value:-30}```
---
<br/>

```csharp
new Question2().Init(new List<int> { -73, -223, 43, 423, 334, -30, 547, 183, 846,-623, 0 });
```
Результат:
>```MINbyABS:{pos:5,value:-30}```
---
<br/>

```csharp
new Question2().Init(new List<int> { -15, -4023, 43, 423, 334, -30, 547, 183, 846,-623, 0 });
```
Результат:
>``` MAXbyABS:{pos:1,value:-4023}``` 
>
>``` MINbyABS:{pos:0,value:-15}``` 
---
<br/>

```csharp
new Question2().Init(new List<int> { 15, -223, 43, 423, 334, -30, 547, 183, 846,-623, 0 });
```
Результат: 
>```Item not found.```
---
<br/>

## Задача 3 
 Реалізуйте алгоритми обчислення арифметичних виразів – перетворення в постфіксну форму, обчислення постфіксного виразу.
```csharp
new Question3().Init("5+3+(5*12+(11-4)/2)");
```
Результат:
>``` 5 3 + 5 12 * 11 4 - 2 / + +```
---
<br/>
```csharp
new Question3().Init("18*(37-46/2)+17*2");
```
Результат:
>```18 37 46 2 / - * 17 2 * + ```
---
<br/>
## Задача 4 
 Напишіть програму, що моделює чергу покупців в каси в магазині. Програма повинна відображати вміст відразу декількох черг. Новий покупець переміщується в чергу натисканням клавіші. Ви повинні самостійно визначити, яким чином він буде вибирати чергу. Обслуговування кожного покупця має випадкову тривалість (в залежності від кількості товарів в кошику). Обслужені покупці видаляються з черги. 

Програма ініціалізує каси, добавляє покупців, для першого доданого покупця діє таймер, а саме ** кількість товару * на середній час обробки касою 1-го товару + похибка** ``` Thread.Sleep((CurrentBuyer.CurrCartList * AVG_Time_To_Service_One_Purchase_SECONDS * 1000) + new Random().Next(1, 5) * 500);``` а всі покупці в черзі, очікують, поки перший покупець завершить свої розрахунки(вийде з черги).

```csharp
// Program.cs 
new Question4().Init();

//Question4.cs  >>init()
//перша каса номер каси 1, середній час опрацювання 1-го товару 1 секунда
 Сashier сashierFirst = new Сashier(1, 1); 
 //друга каса номер каси 2, середній час опрацювання 1-го товару 2 секунди
 Сashier сashierSecond = new Сashier(2, 2); 

 //добавляємо в першу касу Покупця Юрій, з 3-ма покупками.
 сashierFirst.AddNewByuer(new Buyer("Yurii", 3));
 сashierFirst.AddNewByuer(new Buyer("Ann", 2));

 сashierSecond.AddNewByuer(new Buyer("Nikola", 3));

 сashierFirst.AddNewByuer(new Buyer("Vasiliy", 6));
 сashierFirst.AddNewByuer(new Buyer("Nina", 1));

 сashierSecond.AddNewByuer(new Buyer("Nazarii", 2));
 сashierSecond.AddNewByuer(new Buyer("Larisa", 4));

 сashierFirst.AddNewByuer(new Buyer("Alex", 3));
```

Результат:
>```
>Cashier number 1 added enqueue Yurii(Products:3). Total Queue is 1.
>Cashier number 1 added enqueue Ann(Products:2). Total Queue is 2.
>Cashier number 2 added enqueue Nikola(Products:3). Total Queue is 1.
>Cashier number 1 added enqueue Vasiliy(Products:6). Total Queue is 3.
>Cashier number 1 added enqueue Nina(Products:1). Total Queue is 4.
>Cashier number 2 added enqueue Nazarii(Products:2). Total Queue is 2.
>Cashier number 2 added enqueue Larisa(Products:4). Total Queue is 3.
>Cashier number 1 added enqueue Alex(Products:3). Total Queue is 5.
>Cashier number 1 served Yurii.Total Queue is 4.
>Cashier number 1 served Ann.Total Queue is 3.
>Cashier number 2 served Nikola.Total Queue is 2.
>Cashier number 1 served Vasiliy.Total Queue is 2.
>Cashier number 2 served Nazarii.Total Queue is 1.
>Cashier number 1 served Nina.Total Queue is 1.
>Cashier number 1 served Alex.Total Queue is 0.
>Cashier number 2 served Larisa.Total Queue is 0.
>```
---
<br/>
## Задача 5
Реалізуйте основні операції із списками, стеками та чергами (за матеріалами лекцій).
```
~~~ стек:  
  створення стека
  друк(перегляд) стека
  додавання елементів у вернишу стека
  витяг елементів з вершини стека
  перевірка порожнини стека
  очищення стека
~~~черга:
  створення черги
  друг(перегляд черги)
  додавання елемента в кінець черги
  витяг елемента з початку черки
  перевірка порожнечі черги
  очищення черги
```
