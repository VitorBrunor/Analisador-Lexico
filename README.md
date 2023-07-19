# Analisador-Lexico
Projeto desenvolvido para a matéria de Compiladores. O objetico do trabalho é, a paritr de um programa escrito em linguagem C, montar os Lexemas e a Tabela de identificadores (a ser desenvolvida).
Por questões de tempo hábil para a entretga do projeto, o caminho do arquivo em C é definido dentro do código, não podendo ser informado pelo usuário.
O projeto é dividido em 3 arquivos: Analex, Interface e Program.

A classe Analex é onde montamos os lexemas através de Expressões Regulares para melhor legibilidade do código. Anteriormente foi usado uma sequênmciad e IFs aninhados, mas resultou em um código extendo e que abria muitas brechas para bugs na hora de montar os Lexemas.

A classe Interface é a parte visual do porjeto (feito em uma aplicação de console, sem elementos gráficos), onde chamamos o Analex e exibimos os lexemas montados.

A classe Program é onde executamos o porgrama, onde a Interface é chamada e, por consequência, o Analex. 
