// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServerSharp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate void RTSPKeepAliveFuncNative(IntPtr user_data);

	internal class RTSPKeepAliveFuncInvoker {

		RTSPKeepAliveFuncNative native_cb;
		IntPtr __data;
		GLib.DestroyNotify __notify;

		~RTSPKeepAliveFuncInvoker ()
		{
			if (__notify == null)
				return;
			__notify (__data);
		}

		internal RTSPKeepAliveFuncInvoker (RTSPKeepAliveFuncNative native_cb) : this (native_cb, IntPtr.Zero, null) {}

		internal RTSPKeepAliveFuncInvoker (RTSPKeepAliveFuncNative native_cb, IntPtr data) : this (native_cb, data, null) {}

		internal RTSPKeepAliveFuncInvoker (RTSPKeepAliveFuncNative native_cb, IntPtr data, GLib.DestroyNotify notify)
		{
			this.native_cb = native_cb;
			__data = data;
			__notify = notify;
		}

		internal Gst.RtspServer.RTSPKeepAliveFunc Handler {
			get {
				return new Gst.RtspServer.RTSPKeepAliveFunc(InvokeNative);
			}
		}

		void InvokeNative ()
		{
			native_cb (__data);
		}
	}

	internal class RTSPKeepAliveFuncWrapper {

		public void NativeCallback (IntPtr user_data)
		{
			try {
				managed ();
				if (release_on_call)
					gch.Free ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		bool release_on_call = false;
		GCHandle gch;

		public void PersistUntilCalled ()
		{
			release_on_call = true;
			gch = GCHandle.Alloc (this);
		}

		internal RTSPKeepAliveFuncNative NativeDelegate;
		Gst.RtspServer.RTSPKeepAliveFunc managed;

		public RTSPKeepAliveFuncWrapper (Gst.RtspServer.RTSPKeepAliveFunc managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new RTSPKeepAliveFuncNative (NativeCallback);
		}

		public static Gst.RtspServer.RTSPKeepAliveFunc GetManagedDelegate (RTSPKeepAliveFuncNative native)
		{
			if (native == null)
				return null;
			RTSPKeepAliveFuncWrapper wrapper = (RTSPKeepAliveFuncWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}