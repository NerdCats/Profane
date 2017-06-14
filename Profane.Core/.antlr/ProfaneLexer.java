// Generated from c:\nerdcats\Profane\Profane.Core\Profane.g4 by ANTLR 4.7
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ProfaneLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		DERP=1, ID=2, ASSIGN=3, COMMA=4, SMILEY=5, NUMBER=6, STRING=7;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"DERP", "ID", "ASSIGN", "COMMA", "SMILEY", "INT", "NUMBER", "STRING"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'derp'", null, "'='", "','", "':)'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "DERP", "ID", "ASSIGN", "COMMA", "SMILEY", "NUMBER", "STRING"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public ProfaneLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Profane.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\t;\b\1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\3\2\3\2\3\2\3\2"+
		"\3\2\3\3\3\3\7\3\33\n\3\f\3\16\3\36\13\3\3\4\3\4\3\5\3\5\3\6\3\6\3\6\3"+
		"\7\6\7(\n\7\r\7\16\7)\3\b\3\b\3\b\5\b/\n\b\5\b\61\n\b\3\t\3\t\7\t\65\n"+
		"\t\f\t\16\t8\13\t\3\t\3\t\2\2\n\3\3\5\4\7\5\t\6\13\7\r\2\17\b\21\t\3\2"+
		"\6\5\2C\\aac|\6\2\62;C\\aac|\3\2\62;\4\2\f\f$$\2>\2\3\3\2\2\2\2\5\3\2"+
		"\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\3"+
		"\23\3\2\2\2\5\30\3\2\2\2\7\37\3\2\2\2\t!\3\2\2\2\13#\3\2\2\2\r\'\3\2\2"+
		"\2\17+\3\2\2\2\21\62\3\2\2\2\23\24\7f\2\2\24\25\7g\2\2\25\26\7t\2\2\26"+
		"\27\7r\2\2\27\4\3\2\2\2\30\34\t\2\2\2\31\33\t\3\2\2\32\31\3\2\2\2\33\36"+
		"\3\2\2\2\34\32\3\2\2\2\34\35\3\2\2\2\35\6\3\2\2\2\36\34\3\2\2\2\37 \7"+
		"?\2\2 \b\3\2\2\2!\"\7.\2\2\"\n\3\2\2\2#$\7<\2\2$%\7+\2\2%\f\3\2\2\2&("+
		"\t\4\2\2\'&\3\2\2\2()\3\2\2\2)\'\3\2\2\2)*\3\2\2\2*\16\3\2\2\2+\60\5\r"+
		"\7\2,.\7\60\2\2-/\5\r\7\2.-\3\2\2\2./\3\2\2\2/\61\3\2\2\2\60,\3\2\2\2"+
		"\60\61\3\2\2\2\61\20\3\2\2\2\62\66\7$\2\2\63\65\n\5\2\2\64\63\3\2\2\2"+
		"\658\3\2\2\2\66\64\3\2\2\2\66\67\3\2\2\2\679\3\2\2\28\66\3\2\2\29:\7$"+
		"\2\2:\22\3\2\2\2\b\2\34).\60\66\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}