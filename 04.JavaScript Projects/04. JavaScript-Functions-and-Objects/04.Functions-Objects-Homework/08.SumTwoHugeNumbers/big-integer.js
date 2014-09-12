(function (n) {
    "use strict";
    
    function t(n, i) {
        var c, l, a, b, w, p, s = this;
        if (!(s instanceof t)) return new t(n, i);
        if (n instanceof t)
            if (u = 0, i !== c) n += "";
            else {
                s.s = n.s;
                s.e = n.e;
                s.c = (n = n.c) ? n.slice() : n;
                return
            }
        if (typeof n != "string" && (n = (a = typeof n == "number" || Object.prototype.toString.call(n) == "[object Number]") && n === 0 && 1 / n < 0 ? "-0" : n + ""), p = n, i === c && g.test(n)) s.s = n.charAt(0) == "-" ? (n = n.slice(1), -1) : 1;
        else {
            if (i == 10) return k(n, e, r);
            if (n = rt.call(n).replace(/^\+(?!-)/, ""), s.s = n.charAt(0) == "-" ? (n = n.replace(/^-(?!-)/, ""), -1) : 1, i != null ? i != (i | 0) && y || (o = !(i >= 2 && i < 65)) ? (f(i, 2), w = g.test(n)) : (b = "[" + d.slice(0, i = i | 0) + "]+", n = n.replace(/\.$/, "").replace(/^\./, "0."), (w = new RegExp("^" + b + "(?:\\." + b + ")?$", i < 37 ? "i" : "").test(n)) ? (a && (n.replace(/^0\.0*|\./, "").length > 15 && f(p, 0), a = !a), n = tt(n, 10, i, s.s)) : n != "Infinity" && n != "NaN" && (f(p, 1, i), n = "NaN")) : w = g.test(n), !w) {
                s.c = s.e = null;
                n != "Infinity" && (n != "NaN" && f(p, 3), s.s = null);
                u = 0;
                return
            }
        }
        for ((c = n.indexOf(".")) > -1 && (n = n.replace(".", "")), (l = n.search(/e/i)) > 0 ? (c < 0 && (c = l), c += +n.slice(l + 1), n = n.substring(0, l)) : c < 0 && (c = n.length), l = 0; n.charAt(l) == "0"; l++)        ;
        if (i = n.length, a && i > 15 && n.slice(l).length > 15 && f(p, 0), u = 0, (c -= l + 1) > h) s.c = s.e = null;
        else if (l == i || c < v) s.c = [s.e = 0];
        else {
            for (; n.charAt(--i) == "0";)            ;
            for (s.e = c, s.c = [], c = 0; l <= i; s.c[c++] = +n.charAt(l++))            ;
        }
    }
    
    function f(n, t, i, r, f, e) {
        if (y) {
            var c, s = ["new BigNumber", "cmp", "div", "eq", "gt", "gte", "lt", "lte", "minus", "mod", "plus", "times", "toFr"][u ? u < 0 ? -u : u : 1 / u < 0 ? 1 : 0] + "()",
                h = o ? " out of range" : " not a" + (f ? " non-zero" : "n") + " integer";
            h = ([s + " number type has more than 15 significant digits", s + " not a base " + i + " number", s + " base" + h, s + " not a number"][t] || i + "() " + t + (e ? " not a boolean or binary digit" : h + (r ? " or not [" + (o ? " negative, positive" : " integer, integer") + " ]" : ""))) + ": " + n;
            o = u = 0;
            c = new Error(h);
            c.name = "BigNumber Error";
            throw c;
        }
    }
    
    function tt(n, i, r, u) {
        function h(n, t) {
            var u, e = 0,
                s = n.length,
                o, f = [0];
            for (t = t || r; e < s; e++) {
                for (o = f.length, u = 0; u < o; f[u] *= t, u++)                ;
                for (f[0] += d.indexOf(n.charAt(e)), u = 0; u < f.length; u++) f[u] > i - 1 && (f[u + 1] == null && (f[u + 1] = 0), f[u + 1] += f[u] / i ^ 0, f[u] %= i)
            }
            return f.reverse()
        }
        
        function o(n) {
            for (var t = 0, r = n.length, i = ""; t < r; i += d.charAt(n[t++]))            ;
            return i
        }
        var e, c, l, f, s, a;
        if (r < 37 && (n = n.toLowerCase()), (e = n.indexOf(".")) > -1)
            if (e = n.length - e - 1, c = h(new t(r).pow(e).toF(), 10), f = n.split("."), l = h(f[1]), f = h(f[0]), a = it(l, c, l.length - c.length, u, i, f[f.length - 1] & 1), s = a.c, e = a.e) {
                for (; ++e; s.unshift(0))                ;
                n = o(f) + "." + o(s)
            } else s[0] ? f[e = f.length - 1] < i - 1 ? (++f[e], n = o(f)) : n = new t(o(f), i).plus(p).toS(i) : n = o(f);
        else n = o(h(n));
        return n
    }
    
    function it(n, i, r, u, f, o) {
        var y, d, k, w, a, rt = i.slice(),
            g = y = i.length,
            ut = n.length,
            s = n.slice(0, y),
            c = s.length,
            l = new t(p),
            nt = l.c = [],
            tt = 0,
            it = e + (l.e = r) + 1;
        for (l.s = u, u = it < 0 ? 0 : it; c++ < y; s.push(0))        ;
        rt.unshift(0);
        do {
            for (k = 0; k < f; k++) {
                if (y != (c = s.length)) w = y > c ? 1 : -1;
                else
                    for (a = -1, w = 0; ++a < y;)
                        if (i[a] != s[a]) {
                            w = i[a] > s[a] ? 1 : -1;
                            break
                        } if (w < 0) {
                    for (d = c == y ? i : rt; c;) {
                        if (s[--c] < d[c]) {
                            for (a = c; a && !s[--a]; s[a] = f - 1)                            ;
                            --s[a];
                            s[c] += f
                        }
                        s[c] -= d[c]
                    }
                    for (; !s[0]; s.shift())                    ;
                } else break
            }
            nt[tt++] = w ? k : ++k;
            s[0] && w ? s[c] = n[g] || 0 : s = [n[g]]
        } while ((g++ < ut || s[0] != null) && u--);
        return nt[0] || tt == 1 || (--l.e, nt.shift()), tt > it && b(l, e, f, o, s[0] != null), l.e > h ? l.c = l.e = null : l.e < v && (l.c = [l.e = 0]), l
    }
    
    function w(n, i, r) {
        var u = i - (n = new t(n)).e,
            f = n.c;
        if (!f) return n.toS();
        for (f.length > ++i && b(n, u, 10), u = f[0] == 0 ? u + 1 : r ? i : n.e + u + 1; f.length < u; f.push(0))        ;
        return u = n.e, r == 1 || r == 2 && (--i < u || u <= c) ? (n.s < 0 && f[0] ? "-" : "") + (f.length > 1 ? (f.splice(1, 0, "."), f.join("")) : f[0]) + (u < 0 ? "e" : "e+") + u : n.toS()
    }
    
    function b(n, t, i, u, f) {
        var e = n.c,
            s = n.s < 0,
            c = i / 2,
            o = n.e + t + 1,
            h = e[o],
            l = f || o < 0 || e[o + 1] != null;
        if (f = r < 4 ? (h != null || l) && (r == 0 || r == 2 && !s || r == 3 && s) : h > c || h == c && (r == 4 || l || r == 6 && (e[o - 1] & 1 || !t && u) || r == 7 && !s || r == 8 && s), o < 1 || !e[0]) return e.length = 0, e.push(0), f ? (e[0] = 1, n.e = -t) : n.e = 0, n;
        if (e.length = o--, f)
            for (--i; ++e[o] > i;) e[o] = 0, o-- || (++n.e, e.unshift(1));
        for (o = e.length; !e[--o]; e.pop())        ;
        return n
    }
    
    function k(n, i, u) {
        var f = r;
        return r = u, n = new t(n), n.c && b(n, i, 10), r = f, n
    }
    var s = 1e9,
        nt = 1e6,
        e = 20,
        r = 4,
        c = -7,
        a = 21,
        v = -s,
        h = s,
        y = !0,
        l = parseInt,
        i = t.prototype,
        d = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$_",
        o, u = 0,
        g = /^-?(\d+(\.\d*)?|\.\d+)(e[+-]?\d+)?$/i,
        rt = String.prototype.trim || function () {
            return this.replace(/^\s+|\s+$/g, "")
        },
        p = t(1);
    t.ROUND_UP = 0;
    t.ROUND_DOWN = 1;
    t.ROUND_CEIL = 2;
    t.ROUND_FLOOR = 3;
    t.ROUND_HALF_UP = 4;
    t.ROUND_HALF_DOWN = 5;
    t.ROUND_HALF_EVEN = 6;
    t.ROUND_HALF_CEIL = 7;
    t.ROUND_HALF_FLOOR = 8;
    t.config = function () {
        var n, t, g = 0,
            p = {},
            d = arguments,
            k = d[0],
            w = "config",
            i = function (n, t, i) {
                return !((o = n < t || n > i) || l(n) != n && n !== 0)
            },
            b = k && typeof k == "object" ? function () {
                if (k.hasOwnProperty(t)) return (n = k[t]) != null
            } : function () {
                if (d.length > g) return (n = d[g++]) != null
            };
        return b(t = "DECIMAL_PLACES") && (i(n, 0, s) ? e = n | 0 : f(n, t, w)), p[t] = e, b(t = "ROUNDING_MODE") && (i(n, 0, 8) ? r = n | 0 : f(n, t, w)), p[t] = r, b(t = "EXPONENTIAL_AT") && (i(n, -s, s) ? c = -(a = ~~(n < 0 ? -n : +n)) : !o && n && i(n[0], -s, 0) && i(n[1], 0, s) ? (c = ~~n[0], a = ~~n[1]) : f(n, t, w, 1)), p[t] = [c, a], b(t = "RANGE") && (i(n, -s, s) && ~~n ? v = -(h = ~~(n < 0 ? -n : +n)) : !o && n && i(n[0], -s, -1) && i(n[1], 1, s) ? (v = ~~n[0], h = ~~n[1]) : f(n, t, w, 1, 1)), p[t] = [v, h], b(t = "ERRORS") && (n === !!n || n === 1 || n === 0 ? l = (o = u = 0, y = !!n) ? parseInt : parseFloat : f(n, t, w, 0, 0, 1)), p[t] = y, p
    };
    i.abs = i.absoluteValue = function () {
        var n = new t(this);
        return n.s < 0 && (n.s = 1), n
    };
    i.ceil = function () {
        return k(this, 0, 2)
    };
    i.comparedTo = i.cmp = function (n, i) {
        var f, l = this,
            e = l.c,
            o = (u = -u, n = new t(n, i)).c,
            r = l.s,
            c = n.s,
            s = l.e,
            h = n.e;
        if (!r || !c) return null;
        if (f = e && !e[0], i = o && !o[0], f || i) return f ? i ? 0 : -c : r;
        if (r != c) return r;
        if (f = r < 0, i = s == h, !e || !o) return i ? 0 : !e ^ f ? 1 : -1;
        if (!i) return s > h ^ f ? 1 : -1;
        for (r = -1, c = (s = e.length) < (h = o.length) ? s : h; ++r < c;)
            if (e[r] != o[r]) return e[r] > o[r] ^ f ? 1 : -1;
        return s == h ? 0 : s > h ^ f ? 1 : -1
    };
    i.dividedBy = i.div = function (n, i) {
        var r = this.c,
            o = this.e,
            s = this.s,
            f = (u = 2, n = new t(n, i)).c,
            h = n.e,
            c = n.s,
            e = s == c ? 1 : -1;
        return !o && (!r || !r[0]) || !h && (!f || !f[0]) ? new t(!s || !c || (r ? f && r[0] == f[0] : !f) ? NaN : r && r[0] == 0 || !f ? e * 0 : e / 0) : it(r, f, o - h, e, 10)
    };
    i.equals = i.eq = function (n, t) {
        return u = 3, this.cmp(n, t) === 0
    };
    i.floor = function () {
        return k(this, 0, 3)
    };
    i.greaterThan = i.gt = function (n, t) {
        return u = 4, this.cmp(n, t) > 0
    };
    i.greaterThanOrEqualTo = i.gte = function (n, t) {
        return u = 5, (t = this.cmp(n, t)) == 1 || t === 0
    };
    i.isFinite = i.isF = function () {
        return !!this.c
    };
    i.isNaN = function () {
        return !this.s
    };
    i.isNegative = i.isNeg = function () {
        return this.s < 0
    };
    i.isZero = i.isZ = function () {
        return !!this.c && this.c[0] == 0
    };
    i.lessThan = i.lt = function (n, t) {
        return u = 6, this.cmp(n, t) < 0
    };
    i.lessThanOrEqualTo = i.lte = function (n, t) {
        return u = 7, (t = this.cmp(n, t)) == -1 || t === 0
    };
    i.minus = function (n, i) {
        var h, l, a, y, c = this,
            o = c.s;
        if (i = (u = 8, n = new t(n, i)).s, !o || !i) return new t(NaN);
        if (o != i) return n.s = -i, c.plus(n);
        var f = c.c,
            p = c.e,
            e = n.c,
            s = n.e;
        if (!p || !s) {
            if (!f || !e) return f ? (n.s = -i, n) : new t(e ? c : NaN);
            if (!f[0] || !e[0]) return e[0] ? (n.s = -i, n) : new t(f[0] ? c : r == 3 ? -0 : 0)
        }
        if (f = f.slice(), o = p - s) {
            for (h = (y = o < 0) ? (o = -o, f) : (s = p, e), h.reverse(), i = o; i--; h.push(0))            ;
            h.reverse()
        } else
            for (a = ((y = f.length < e.length) ? f : e).length, o = i = 0; i < a; i++)
                if (f[i] != e[i]) {
                    y = f[i] < e[i];
                    break
                } if (y && (h = f, f = e, e = h, n.s = -n.s), (i = -((a = f.length) - e.length)) > 0)
            for (; i--; f[a++] = 0)            ;
        for (i = e.length; i > o;) {
            if (f[--i] < e[i]) {
                for (l = i; l && !f[--l]; f[l] = 9)                ;
                --f[l];
                f[i] += 10
            }
            f[i] -= e[i]
        }
        for (; f[--a] == 0; f.pop())        ;
        for (; f[0] == 0; f.shift(), --s)        ;
        return (s < v || !f[0]) && (f[0] || (n.s = r == 3 ? -1 : 1), f = [s = 0]), n.c = f, n.e = s, n
    };
    i.modulo = i.mod = function (n, i) {
        var f = this,
            h = f.c,
            c = (u = 9, n = new t(n, i)).c,
            o = f.s,
            s = n.s;
        return (i = !o || !s || c && !c[0], i || h && !h[0]) ? new t(i ? NaN : f) : (f.s = n.s = 1, i = n.cmp(f) == 1, f.s = o, n.s = s, i ? new t(f) : (o = e, s = r, e = 0, r = 1, f = f.div(n), e = o, r = s, this.minus(f.times(n))))
    };
    i.negated = i.neg = function () {
        var n = new t(this);
        return n.s = -n.s || null, n
    };
    i.plus = function (n, i) {
        var o, c = this,
            f = c.s;
        if (i = (u = 10, n = new t(n, i)).s, !f || !i) return new t(NaN);
        if (f != i) return n.s = -i, c.minus(n);
        var l = c.e,
            r = c.c,
            s = n.e,
            e = n.c;
        if (!l || !s) {
            if (!r || !e) return new t(f / 0);
            if (!r[0] || !e[0]) return e[0] ? n : new t(r[0] ? c : f * 0)
        }
        if (r = r.slice(), f = l - s) {
            for (o = f > 0 ? (s = l, e) : (f = -f, r), o.reverse(); f--; o.push(0))            ;
            o.reverse()
        }
        for (r.length - e.length < 0 && (o = e, e = r, r = o), f = e.length, i = 0; f; i = (r[--f] = r[f] + e[f] + i) / 10 ^ 0, r[f] %= 10)        ;
        for (i && (r.unshift(i), ++s > h && (r = s = null)), f = r.length; r[--f] == 0; r.pop())        ;
        return n.c = r, n.e = s, n
    };
    i.toPower = i.pow = function (n) {
        var i = n * 0 == 0 ? n | 0 : n,
            r = new t(this),
            u = new t(p);
        if (((o = n < -nt || n > nt) && (i = n / 0) || l(n) != n && n !== 0 && !(i = NaN)) && !f(n, "exponent", "pow") || !i) return new t(Math.pow(r.toS(), i));
        for (i = i < 0 ? -i : i;;) {
            if (i & 1 && (u = u.times(r)), i >>= 1, !i) break;
            r = r.times(r)
        }
        return n < 0 ? p.div(u) : u
    };
    i.round = function (n, t) {
        return n = n == null || ((o = n < 0 || n > s) || l(n) != n) && !f(n, "decimal places", "round") ? 0 : n | 0, t = t == null || ((o = t < 0 || t > 8) || l(t) != t && t !== 0) && !f(t, "mode", "round") ? r : t | 0, k(this, n, t)
    };
    i.squareRoot = i.sqrt = function () {
        var o, u, c, s, h = this,
            n = h.c,
            i = h.s,
            f = h.e,
            l = e,
            a = r,
            v = new t("0.5");
        if (i !== 1 || !n || !n[0]) return new t(!i || i < 0 && (!n || n[0]) ? NaN : n ? h : 1 / 0);
        for (i = Math.sqrt(h.toS()), r = 1, i == 0 || i == 1 / 0 ? (o = n.join(""), o.length + f & 1 || (o += "0"), u = new t(Math.sqrt(o) + ""), u.c || (u.c = [1]), u.e = ((f + 1) / 2 | 0) - (f < 0 || f & 1)) : u = new t(o = i.toString()), c = u.e, i = c + (e += 4), i < 3 && (i = 0), f = i;;)
            if (s = u, u = v.times(s.plus(h.div(s))), s.c.slice(0, i).join("") === u.c.slice(0, i).join(""))
                if (n = u.c, i = i - (o && u.e < c), n[i] == 9 && n[i - 1] == 9 && n[i - 2] == 9 && (n[i - 3] == 9 || o && n[i - 3] == 4)) {
                    if (o && n[i - 3] == 9 && (s = u.round(l, 0), s.times(s).eq(h))) return r = a, e = l, s;
                    e += 4;
                    i += 4;
                    o = ""
                } else {
                    if (!n[f] && !n[f - 1] && !n[f - 2] && (!n[f - 3] || n[f - 3] == 5) && (n.length > f - 2 && (n.length = f - 2), !u.times(u).eq(h))) {
                        while (n.length < f - 3) n.push(0);
                        n[f - 3]++
                    }
                    return r = a, b(u, e = l, 10), u
                }
    };
    i.times = function (n, i) {
        var f, l = this,
            e = l.c,
            o = (u = 11, n = new t(n, i)).c,
            s = l.e,
            r = n.e,
            c = l.s;
        if (n.s = c == (i = n.s) ? 1 : -1, !s && (!e || !e[0]) || !r && (!o || !o[0])) return new t(!c || !i || e && !e[0] && !o || o && !o[0] && !e ? NaN : !e || !o ? n.s / 0 : n.s * 0);
        for (n.e = s + r, (c = e.length) < (i = o.length) && (f = e, e = o, o = f, r = c, c = i, i = r), r = c + i, f = []; r--; f.push(0))        ;
        for (s = i - 1; s > -1; s--) {
            for (i = 0, r = c + s; r > s; i = f[r] + o[s] * e[r - s - 1] + i, f[r--] = i % 10 | 0, i = i / 10 | 0)            ;
            i && (f[r] = (f[r] + i) % 10)
        }
        for (i && ++n.e, f[0] || f.shift(), r = f.length; !f[--r]; f.pop())        ;
        return n.c = n.e > h ? n.e = null : n.e < v ? [n.e = 0] : f, n
    };
    i.toExponential = i.toE = function (n) {
        return w(this, (n == null || ((o = n < 0 || n > s) || l(n) != n && n !== 0) && !f(n, "decimal places", "toE")) && this.c ? this.c.length - 1 : n | 0, 1)
    };
    i.toFixed = i.toF = function (n) {
        var u, t, r, i = this;
        return n == null || ((o = n < 0 || n > s) || l(n) != n && n !== 0) && !f(n, "decimal places", "toF") || (r = i.e + (n | 0)), u = c, n = a, c = -(a = 1 / 0), r == t ? t = i.toS() : (t = w(i, r), i.s < 0 && i.c && (i.c[0] ? t.indexOf("-") < 0 && (t = "-" + t) : t = t.replace(/^-/, ""))), c = u, a = n, t
    };
    i.toFraction = i.toFr = function (n) {
        var k, nt, c, l, i, s, d, a = l = new t(p),
            v = c = new t("0"),
            w = this,
            g = w.c,
            tt = h,
            it = e,
            rt = r,
            b = new t(p);
        if (!g) return w.toS();
        for (d = b.e = g.length - w.e - 1, (n == null || (!(u = 12, s = new t(n)).s || (o = s.cmp(a) < 0 || !s.c) || y && s.e < s.c.length - 1) && !f(n, "max denominator", "toFr") || (n = s).cmp(b) > 0) && (n = d > 0 ? b : a), h = 1 / 0, s = new t(g.join("")), e = 0, r = 1;;) {
            if (k = s.div(b), i = l.plus(k.times(v)), i.cmp(n) == 1) break;
            l = v;
            v = i;
            a = c.plus(k.times(i = a));
            c = i;
            b = s.minus(k.times(i = b));
            s = i
        }
        return i = n.minus(l).div(v), c = c.plus(i.times(a)), l = l.plus(i.times(v)), c.s = a.s = w.s, e = d * 2, r = rt, nt = a.div(v).minus(w).abs().cmp(c.div(l).minus(w).abs()) < 1 ? [a.toS(), v.toS()] : [c.toS(), l.toS()], h = tt, e = it, nt
    };
    i.toPrecision = i.toP = function (n) {
        return n == null || ((o = n < 1 || n > s) || l(n) != n) && !f(n, "precision", "toP") ? this.toS() : w(this, --n | 0, 2)
    };
    i.toString = i.toS = function (n) {
        var u, t, e, r = this,
            i = r.e;
        if (i === null) t = r.s ? "Infinity" : "NaN";
        else {
            if (n === u && (i <= c || i >= a)) return w(r, r.c.length - 1, 1);
            if (t = r.c.join(""), i < 0) {
                for (; ++i; t = "0" + t)                ;
                t = "0." + t
            } else if (e = t.length, i > 0)
                if (++i > e)
                    for (i -= e; i--; t += "0")                    ;
                else i < e && (t = t.slice(0, i) + "." + t.slice(i));
            else if (u = t.charAt(0), e > 1) t = u + "." + t.slice(1);
            else if (u == "0") return u;
            if (n != null)
                if ((o = !(n >= 2 && n < 65)) || n != (n | 0) && y) f(n, "base", "toS");
                else if (t = tt(t, n | 0, 10, r.s), t == "0") return t
        }
        return r.s < 0 ? "-" + t : t
    };
    i.toNumber = i.toN = function () {
        var n = this;
        return +n || (n.s ? 0 * n.s : NaN)
    };
    i.valueOf = function () {
        return this.toS()
    };
    typeof module != "undefined" && module.exports ? module.exports = t : typeof define == "function" && define.amd ? define(function () {
        return t
    }) : n.BigNumber = t
})(this)