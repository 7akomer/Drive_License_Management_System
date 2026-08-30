using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography; // مكتبة Argon2
using System.Security.Cryptography;   // مكتبة Salt العشوائي والمقارنة الآمنة
using System.Text;

namespace Driver_License_System_DAL
{

    public class PasswordHasher
    {
        // دالة تشفير كلمة المرور
        public static string HashPassword(string password)
        {
            byte[] salt = GenerateSalt(); // توليد Salt عشوائي

            // إنشاء كائن Argon2 وتمرير كلمة المرور كـ bytes
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,              // الـ Salt العشوائي
                DegreeOfParallelism = 2,  // عدد الـ Threads المستخدمة
                MemorySize = 65536,       // حجم الذاكرة المستخدمة 64MB
                Iterations = 3            // عدد مرات تكرار الخوارزمية
            };

            byte[] hash = argon2.GetBytes(32); // تنفيذ الهاش والحصول على 32 byte

            // دمج الـ Salt مع الـ Hash بفاصل : لحفظهم معاً في قاعدة البيانات
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        // دالة التحقق من كلمة المرور عند تسجيل الدخول
        public static bool VerifyPassword(string password, string storedHash)
        {
            string[] parts = storedHash.Split(':'); // تقسيم القيمة المحفوظة لجزئين
            byte[] salt = Convert.FromBase64String(parts[0]);         // استخراج الـ Salt
            byte[] originalHash = Convert.FromBase64String(parts[1]); // استخراج الـ Hash الأصلي

            // إعادة إنشاء Argon2 بنفس الإعدادات والـ Salt القديم
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 2,
                MemorySize = 65536,
                Iterations = 3
            };

            byte[] newHash = argon2.GetBytes(32); // تشفير كلمة المرور الجديدة

            // مقارنة آمنة تمنع Timing Attack
            return FixedTimeEquals(originalHash, newHash);
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int diff = 0;

            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }
        // دالة توليد Salt عشوائي
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];    // مصفوفة فارغة 16 byte

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            } // ملئها بأرقام عشوائية آمنة
            return salt;
        }


    }
}
