O projeto trata-se de uma aplicação web desenvolvida com Asp .Net 7.0 MVC(Model View Controller).
O objetivo da aplicação é simular o cadastro de categorias e produtos.
A tela inicial abre com uma grid de Categorias podendo adicionar, editar, excluir ou redirecionar para a tela de produtos que tem as mesmas funcionalidades.
Não tem como adicionar um produto sem antes adicionar uma Categoria.

Foi utilizado o padrão de projeto Handlers(Mediator) para realizar a camada de serviço entre as controller e repositórios removendo o acoplamento.
Utilizado um dos pilares da POO (Interfaces) que funciona como um contrato entre a classe que herda a interface que define os metodos que devem ser implementados.
Utilizado padrão de repository por entidade.

Observação para testes:
1° passo: configurar a connectionstring, dentro da pasta do projeto tem um arquivo chamado **appsettings.json** definir a string de conexão MySql **DefaultConnection** 
Exemplo: "server=localhost; port=3306; database=citel; user=root; password=suaSenha; Persist Security Info=False; Connect Timeout=300"
2° passo: se houver erro de compilação no projeto, basta remover a pasta Bin e restaurar as depêndencias nuget, 
  pode realizar essa ação abrindo o projeto no visual studio 2022 e clicando com botão direito na solução e selecionando a opção **Restaurar Pacotes Nugets**
3° passo: disponibilizei duas formas de popular o banco de dados.
   primeira: abrir o console do gerenciador de pacotes ou o proprio powerShell e executar o comando **update-database**, 
     está ação vai executar os migrations adicionado ao projeto no banco de dados via EntityFrameowrk
   segunda: dentro do projeto tem uma pasta chamada **ScriptMySql** e dentro dela tem dois scripts sql **ScriptCreateTable** e **ScriptDeDados**, 
     execute os dois arquivos nessa ordem e o banco será criado e populado.
     
Versão DotNet 7.0.302
Versão Node v18.16.0
Versão NPM 9.5.1

npm install -g npm@9.5.1
link instalação node https://nodejs.org/en/download
link instalação dotnet https://dotnet.microsoft.com/pt-br/download/dotnet
