using System;

namespace QueryProcessorEngine
{
	public class Token
	{
		int line;
		int column;
		string value;
		string kind;
		string _POStag;

		public Token(string kind, string value, int line, int column)
		{
			this.kind = kind;
			this.value = value;
			this.line = line;
			this.column = column;
		}

		public int Column
		{
			get { return column; }
		}

		public string Kind
		{
			get { return kind; }
            set { kind = value; }
		}

		public int Line
		{
			get { return line; }
		}

		public string Value
		{
			get { return value; }
		}
		
		public string POSTag
		{
			get { return _POStag; }
			set { _POStag = value; }
	}

}
