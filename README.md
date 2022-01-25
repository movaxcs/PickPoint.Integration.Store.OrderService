# PickPoint.Integration.Store.OrderService
Инструменты: VS2022, .NET 6.0, EFCore 6.0 (UseInMemoryDatabase), Swagger

Комментарий: 

Сущности - Order, Postamat, Recipient, Product (у Postamat ключ натуральный, у остальных суррогатные)

Контроль формата телефона в методах api/recipients post и put 

Контроль формата номера постамата в методах api/postamats post и put 

Один DTO (просто для примера) и там аттрибуты Required, DefaultValue(...) только для того, чтобы swagger было удобнее использовать для тестирования, в реальной жизни они, конечно, не нужны)

Репозиторий, сервисы не делал, т.к. для этого примера проще в контроллере с контекстом поработать

![Screenshot 2022-01-25 222141](https://user-images.githubusercontent.com/1316638/151045140-f7ccb2db-0b96-485f-87f3-d5af201406a0.png)

![Screenshot 2022-01-25 222236](https://user-images.githubusercontent.com/1316638/151045164-c82fc766-4535-4790-9323-7b0d6bc4df56.png)
