namespace Motoristas_Testes
{
    public class Motoristas
    {
        public string EncontrarMotoristas(List<Pessoa> pessoas)
        {
            List<Pessoa> motoristas = new();
            foreach (var pessoa in pessoas)
            {
                bool valid = true;
                #region v1
                // versao 1 = remove pessoa menor de idade e lanca excecao
                //if (pessoa.Idade < 18)
                //{
                //    throw new InvalidDataException($"Lista inválida: {pessoa.Nome} tem {pessoa.Idade}, e não pode possuir habilitação!\n" +
                //                        $"Esta pessoa deve ser removida da lista");                    
                //}
                #endregion
                #region v2
                // versao2 = remove a pessoa menor de idade e continuar a execucao do metodo:

                try
                {
                    if (pessoa.Idade < 18)
                    {
                        throw new InvalidDataException($"Lista inválida: {pessoa.Nome} tem {pessoa.Idade}, e não pode possuir habilitação!\n" +
                                            $"Esta pessoa deve ser removida da lista");
                    }
                }
                catch (InvalidDataException e)
                {                      
                    valid = false;
                    Console.WriteLine(e.Message);                    
                }
                #endregion

                if (pessoa.PossuiHabilitacaoB && valid)
                {
                    motoristas.Add(pessoa);
                    if (motoristas.Count == 2)
                    {
                        return $"Uhuu! Os motorista são {motoristas[0].Nome} e {motoristas[1].Nome}";
                    }
                }
            }

            throw new Exception("A viagem não será realizada devido falta de motoristas!");
        }
    }
}
