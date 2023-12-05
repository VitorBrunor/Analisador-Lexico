using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Compilador.lexico
{
    public class Analex
    {
        public void montarLexemas()
        {
            string inputFilePath = "C:\\Users\\vitor\\Downloads\\Analisador-Lexico\\entrada.c";
            string outputFilePath = "C:\\Users\\vitor\\Downloads\\Analisador-Lexico\\analex.txt";

            try
            {
                // Verifica se o arquivo de entrada existe
                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine($"Arquivo de entrada não encontrado: {inputFilePath}");
                    return;
                }

                // Lê todo o conteúdo do arquivo de entrada
                string conteudo = File.ReadAllText(inputFilePath);

                // Remove os comentários antes da análise léxica
                string removeComentario = RemoveComments(conteudo);

                // Realiza a análise léxica para identificar os tokens
                List<Token> tokens = LexicalAnalysis(removeComentario);

                // Cria um novo arquivo com os tokens identificados
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    Console.WriteLine("Análise léxica concluída e arquivo criado com sucesso!");

                    writer.WriteLine("Lexemas encontrados:");
                    foreach (Token token in tokens)
                    {
                        if (token.Type == TokenType.Reservada)
                        {
                            writer.WriteLine($"<{token.Value},>");
                            Console.WriteLine($"<{token.Value}>");
                        }
                        else
                        {
                            writer.WriteLine($"<{token.Type}, {token.Value}>");
                            Console.WriteLine($"<{token.Type}, {token.Value}>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        static string RemoveComments(string sourceCode)
        {
            // Remove comentários de linha
            sourceCode = Regex.Replace(sourceCode, @"//.*", "");

            // Remove comentários de bloco
            sourceCode = Regex.Replace(sourceCode, @"/\*.*?\*/", "", RegexOptions.Singleline);

            return sourceCode;
        }

        static List<Token> LexicalAnalysis(string sourceCode)
        {
            List<Token> tokens = new List<Token>();

            string pattern = @"\b(using|class|static|void|int|double|string|Console|WriteLine)\b|\d+|"".+?""|[+\-/=;(),.]|\w+";
            Regex regex = new Regex(pattern);

            foreach (Match match in regex.Matches(sourceCode))
            {
                TokenType type;

                if (int.TryParse(match.Value, out _))
                {
                    type = TokenType.Inteiro;
                }
                else if (match.Value.StartsWith("\"") && match.Value.EndsWith("\""))
                {
                    type = TokenType.String;
                }
                else if (Regex.IsMatch(match.Value, @"^[+\-*/=;(),.]$"))
                {
                    type = TokenType.Operador;
                }
                else if (Regex.IsMatch(match.Value, @"\b(using|class|static|void|int|double|string|Console|WriteLine|main|Main)\b"))
                {
                    type = TokenType.Reservada;
                }
                else
                {
                    type = TokenType.ID;
                }
                if (Regex.IsMatch(match.Value.Trim(), @"^#include|include|stdio|stdlib.*"))
                {
                    continue;
                }

                tokens.Add(new Token(type, match.Value.Trim()));
            }

            return tokens;
        }
    }

    public enum TokenType
    {
        Reservada,
        Inteiro,
        String,
        ID,
        Operador,
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
