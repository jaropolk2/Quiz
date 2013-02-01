using System.Collections.Generic;


namespace GallerySM.Domain.Games.Quiz
{
    public interface IPergunta
    {   
        IPergunta CriarPergunta(string descricao, IList<string> descricoesRespostas);
    }
}
