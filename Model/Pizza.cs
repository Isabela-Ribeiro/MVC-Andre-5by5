﻿using System;

namespace Model
{
    public class Pizza : Refeicao
    {
        public const String INSERT = "INSERT INTO TB_REFEICAO (descricao , valor)  VALUES ('{0}', {1})";
        public const String UPDATE = "UPDATE TB_REFEICAO SET descricao = '{0}', valor = {1} WHERE id = {2}";
        public const String DELETE = "DELETE TB_REFEICAO  WHERE id = {0}";
        public const String SELECT = "SELECT id, descricao , valor FROM TB_REFEICAO";
        public const String SELECTBYID = "SELECT id, descricao,valor FROM TB_REFEICAO WHERE id = {0}";
       
    }
}
