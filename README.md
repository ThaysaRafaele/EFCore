# EFCore

Esta aplicação possui as seguintes entidades:
Cliente, Pedido e Item do Pedido.<br>
* Cliente possui relacionamento com Pedido: um cliente poderá ter
vários pedidos.
* Item do pedido possui relacionamento com Pedido: um pedido
pode ter vários itens (um pedido não pode existir sem ao menos um item).
* Pedido possui um valor total com os itens e a quantidade de cada item.
* Cliente: Id, Nome e E-mail.
* Pedido: Id, Número do pedido, Data de criação.
* Item do Pedido: Id, Nome, Valor Unitário.
<br>
Aplicando injeção de dependência.
<br>Aplicação com 4 camadas (Domain, Data, Application e Presentation).
