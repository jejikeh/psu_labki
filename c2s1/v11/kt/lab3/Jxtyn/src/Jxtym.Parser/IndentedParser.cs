using System;
using System.Collections.Generic;
using System.Linq;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;

namespace Jxtym.Parser
{
    public class IndentedParser
    {
        
        [Production("id : ID")]
        public Ast id(Token<IndentedLangLexer> tok)
        {
            return new Identifier(tok.Value);
        }
        
        [Production("hex : HEX")]
        public Ast hexademical(Token<IndentedLangLexer> tok)
        {

            var num = Convert.ToInt32(tok.Value.Substring(1, tok.Value.Length - 2), 16);
            return new Integer(num);
        }

        [Production("statement: [setHex|ifthenelse]")]
        public Ast Statement(Ast stat)
        {
            return stat as Statement;
        }
        
        
        [Production("setHex : id SET[d] hex")]
        public Ast SetHex(Identifier id, Integer i)
        {
            return new Set<Integer>(id, i);
        }
        
        [Production("cond : id EQ[d] hex")]
        public Ast Condi(Identifier id, Integer i)
        {
            return new Cond(id, i);
        }

        [Production("root: statement*")]
        public Ast Root(List<Ast> statements)
        {
            return new Block(statements);
        }
        
        [Production("ifthenelse: IF cond THEN block (ELSE[d] block)?")]
        public Ast ifthenelse(Token<IndentedLangLexer> si, Cond cond,Token<IndentedLangLexer> ghostThen, Block thenblk, ValueOption<Group<IndentedLangLexer,Ast>> elseblk)
        {
            
            var previous = si.Previous(Channels.Comments);
            string comment = null;
            // previous token may not be a comment so we have to check if not null
            if (previous != null && (previous.TokenID == IndentedLangLexer.SINGLE_COMMENT || previous.TokenID == IndentedLangLexer.MULTI_COMMENT))
            {
                comment = previous?.Value;
            }
            
            var eGrp = elseblk.Match(
                x => {
                return x;
            }, () =>
            {
                return null;
            });
            var eBlk = eGrp?.Value(0) as Block;
            return new IfThenElse(cond, thenblk, eBlk, comment);
        }

        [Production("block : INDENT[d] statement* UINDENT[d]")]
        public Ast Block(List<Ast> statements)
        {
            return new Block(statements);
        }
    }
}