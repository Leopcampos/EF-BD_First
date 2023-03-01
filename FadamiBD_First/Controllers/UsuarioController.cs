using FadamiBD_First.Data;
using FadamiBD_First.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FadamiBD_First.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DBFirst_FadamiContext _context;
        private readonly IValidator<Usuario> _usuarioValidator;

        public UsuarioController(DBFirst_FadamiContext context, IValidator<Usuario> usuarioValidator)
        {
            _context = context;
            _usuarioValidator = usuarioValidator;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                var resultadoValidacao = _usuarioValidator.Validate(usuario);
                if (resultadoValidacao.IsValid)
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    foreach (var erro in resultadoValidacao.Errors)
                    {
                        ModelState.AddModelError(erro.PropertyName, erro.ErrorMessage);
                    }
                    return View(usuario);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o usuário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Criar");
            }
        }

        public IActionResult Editar(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Codigo == id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuarioSemSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = new Usuario()
                    {
                        Codigo = usuarioSemSenhaModel.Codigo,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Cpf = usuarioSemSenhaModel.Cpf,
                        Senha = usuarioSemSenhaModel.Senha,
                        BlAtivo = usuarioSemSenhaModel.BlAtivo
                    };

                    // Aqui, você pode usar o validador de usuário para validar o objeto usuario
                    ValidationResult result = _usuarioValidator.Validate(usuario);
                    if (!result.IsValid)
                    {
                        // Se houver erros de validação, adicione cada erro ao ModelState
                        foreach (ValidationFailure failure in result.Errors)
                        {
                            ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                        }
                        // Retorne a view com os erros de validação
                        return View(usuario);
                    }

                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuarioSemSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}