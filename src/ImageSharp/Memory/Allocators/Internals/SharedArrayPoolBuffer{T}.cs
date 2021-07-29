using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Memory.Internals
{
    internal class SharedArrayPoolBuffer<T> : ManagedBufferBase<T>
        where T : struct
    {
        private readonly int lengthInBytes;
        protected byte[] array;

        public SharedArrayPoolBuffer(int lengthInElements)
        {
            this.lengthInBytes = lengthInElements * Unsafe.SizeOf<T>();
            this.array = ArrayPool<byte>.Shared.Rent(this.lengthInBytes);
        }

        ~SharedArrayPoolBuffer() => this.Dispose(false);

        protected override void Dispose(bool disposing)
        {
            if (this.array == null)
            {
                return;
            }

            ArrayPool<byte>.Shared.Return(this.array);
            this.array = null;
        }

        public override Span<T> GetSpan() => MemoryMarshal.Cast<byte, T>(this.array.AsSpan(0, this.lengthInBytes));

        protected override object GetPinnableObject() => this.array;
    }

    internal class SharedArrayPoolByteBuffer : SharedArrayPoolBuffer<byte>, IManagedByteBuffer
    {
        public SharedArrayPoolByteBuffer(int lengthInElements)
            : base(lengthInElements)
        {
        }

        public byte[] Array => this.array;
    }
}