using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Models.ModelView;

namespace com.cake_lovers.www.Services
{
    public class ContatoService
    {
        private readonly CakeLoversDbContext _context;

        public ContatoService(CakeLoversDbContext context)
        {
            _context = context;
        }
        public int AddContato(ContatoModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Não há dados para adicionar um contato");
            }
            var contato = new Contato()
            {
                Mensagem= model.Mensagem,
                Nome= model.Nome,
                Date= DateTime.Now,
                Email= model.Email,
            };
            _context.Contatos.Add(contato);
            return _context.SaveChanges();
        }
        public List<Contato> GetAllContatos()
        {
            return _context.Contatos.ToList();
        }
       
        public Contato GetContatoPorId(int? id)
        {
            if (id.HasValue)
            {
                return _context.Contatos.FirstOrDefault(p => p.ContatoId == id);
            }
            throw new ArgumentNullException("Não foi possível encontrar o contato solicitado");
        }
      
        public void DeletarContatoPorId(int? id)
        {
            var contato = _context.Contatos.FirstOrDefault(predicate => predicate.ContatoId == id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                _context.SaveChanges();
            }

        }
    }
}
