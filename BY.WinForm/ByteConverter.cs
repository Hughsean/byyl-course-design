//实现字节与对象转换函数
using System.Text.Json;

namespace BY.WinForm
{
    internal class ByteConverter
    {
        /// <summary>
        /// 将对象实例转字节数组
        /// </summary>
        /// <param name="obj"> 对象实例 </param>
        /// <param name="T"> 对象类型 </param>
        /// <returns> 字节数组 </returns>
        public static byte[] ObjToByte(object? obj)
        {
            using MemoryStream ms = new();
            JsonSerializer.Serialize(ms, obj);
            return ms.ToArray();
        }
        /// <summary>
        /// 将字节数组转化为对象实例
        /// </summary>
        /// <param name="bt"> 字节数组 </param>
        /// <param name="T"> 类型 </param>
        /// <returns> 对象实例 </returns>
        public static object? ByteToObj(byte[] bt, Type T)
        { return JsonSerializer.Deserialize(bt, T); }
    }
}
