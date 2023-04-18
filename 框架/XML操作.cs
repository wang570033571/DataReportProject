using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace 框架
{
    public static class XML操作
    {
        /// 读取数据
        /// </summary>
        /// <param name="path">文件</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XML操作.读取(path, "/Node", "")
         * XML操作.读取(path, "/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public static string 读取(string 文件, string 节点, string 属性)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(文件);
                XmlNode xn = doc.SelectSingleNode(节点);
                value = (属性.Equals("") ? xn.InnerText : xn.Attributes[属性].Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return value;
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">文件</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XML操作.插入(path, "/Node", "Element", "", "Value")
         * XML操作.插入(path, "/Node", "Element", "Attribute", "Value")
         * XML操作.插入(path, "/Node", "", "Attribute", "Value")
         ************************************************/
        public static void 插入(string 文件, string 节点, string 元素, string 属性, string 值)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(文件);
                XmlNode xn = doc.SelectSingleNode(节点);
                if (元素.Equals(""))
                {
                    if (!属性.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(属性, 值);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(元素);
                    if (属性.Equals(""))
                        xe.InnerText = 值;
                    else
                        xe.SetAttribute(属性, 值);
                    xn.AppendChild(xe);
                }
                doc.Save(文件);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="path">文件</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XML操作.更新(path, "/Node", "", "Value")
         * XML操作.更新(path, "/Node", "Attribute", "Value")
         ************************************************/
        public static void 更新(string 文件, string 节点, string 属性, string 值)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(文件);
                XmlNode xn = doc.SelectSingleNode(节点);
                XmlElement xe = (XmlElement)xn;
                if (属性.Equals(""))
                    xe.InnerText = 值;
                else
                    xe.SetAttribute(属性, 值);
                doc.Save(文件);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">文件</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XML操作.删除(path, "/Node", "")
         * XML操作.删除(path, "/Node", "Attribute")
         ************************************************/
        public static void 删除(string 文件, string 节点, string 属性)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(文件);
                XmlNode xn = doc.SelectSingleNode(节点);
                XmlElement xe = (XmlElement)xn;
                if (属性.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(属性);
                doc.Save(文件);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
