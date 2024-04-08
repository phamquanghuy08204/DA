using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLONKY5.Models;
using System.Security.Cryptography;
using BTLONKY5.Util;


namespace BTLONKY5.Controllers
{
    public class AccountController : BaseController
    {
        private readonly QLDBcontext _context;

        public AccountController(QLDBcontext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
              return _context.Accounts != null ? 
                          View(await _context.Accounts.ToListAsync()) :
                          Problem("Entity set 'QLDBcontext.Accounts'  is null.");
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,PassWord,Role,Img")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        //-----------------------------------------------------------------------------------
        public async Task<IActionResult> Profile()
        {
			if (!IsLogin)
			{
				return RedirectToAction("Login", "Account");
			}
			else
			{
				// Lấy tên người dùng từ session
				var userName = HttpContext.Session.GetString("USER_NAME");

				// Kiểm tra xem người dùng có tồn tại trong cơ sở dữ liệu không
				var user = await _context.Accounts.FirstOrDefaultAsync(m => m.UserName == userName);
				if (user == null)
				{
					// Nếu không tìm thấy người dùng, có thể xử lý trường hợp này theo ý của bạn,
					// ví dụ: hiển thị một thông báo lỗi hoặc chuyển hướng đến trang khác
					return NotFound();
				}

				// Trả về view và truyền thông tin người dùng
				return View(user);
			}
		}
        
        //----------------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------------
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ID,UserName,PassWord")] Account model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên người dùng có tồn tại trong cơ sở dữ liệu không
                var loginUser = await _context.Accounts.FirstOrDefaultAsync(m => m.UserName == model.UserName);
                if (loginUser == null)
                {
                    ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không chính xác.");
                    return View(model);
                }

                // Kiểm tra xem mật khẩu đã nhập có khớp với mật khẩu đã lưu trong cơ sở dữ liệu không
                SHA256 hashMethod = SHA256.Create();
                if (Cryptography.VerifyHash(hashMethod, model.PassWord, loginUser.PassWord))
                {
                    // Lưu trạng thái người dùng vào Session
                    HttpContext.Session.SetString("UserName", model.UserName);
                    HttpContext.Session.SetString("Role", loginUser.Role.ToString());

                    // Chuyển hướng đến trang chính sau khi đăng nhập thành công
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không chính xác.");
                    return View(model);
                }
            }

            // Trả về trang đăng nhập nếu dữ liệu không hợp lệ
            return View(model);
    }
        //--------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,PassWord")] Account model)
        {
           if (ModelState.IsValid)
            {
                // Mã hóa mật khẩu
                SHA256 hashMethod = SHA256.Create();
                model.PassWord = Util.Cryptography.GetHash(hashMethod, model.PassWord);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(model);
        }
            
        
        //--------------------------------------------------------------------------------------------------------------
        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,PassWord,Role,Img")] Account account)
        {
            if (id != account.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'QLDBcontext.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
