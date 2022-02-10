﻿using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeIgual(object obj1, object obj2, string message)
        {
            if (obj1.Equals(obj2))
                throw new DomainException(message);
        }

        public static void ValidarSeDiferente(object obj1, object obj2, string message)
        {
            if (!obj1.Equals(obj2))
                throw new DomainException(message);
        }

        public static void ValidarCaracteres(string valor, int maximo, string message)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
                throw new DomainException(message);
        }
        public static void ValidarCaracteres(string valor, int minimo, int maximo, string message)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
                throw new DomainException(message);
        }
        public static void ValidarExpressao(string pattern, string valor, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(valor))
                throw new DomainException(message);
        }

        public static void ValidarSeVazio(string valor,string message)
        {
            if(valor == null || valor.Trim().Length == 0)
                throw new DomainException(message);
        }
        
        public static void ValidarSeNulo(object obj1, string message)
        {
            if (obj1 == null) 
                throw new DomainException(message);
        }
        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);                
        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
                 throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo) 
                throw new DomainException(mensagem);
        }

        public static void ValidarSeFalso(bool boolvalor, string mensagem)
        {
            if (!boolvalor)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeVerdadeiro(bool boolvalor, string mensagem)
        {
            if (boolvalor)
                 throw new DomainException(mensagem);
        }

    }
}
