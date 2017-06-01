/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using TouchScript.Hit;
using TouchScript.InputSources;
using UnityEngine;

namespace TouchScript.Pointers
{
    public class FakePointer : IPointer
    {

        #region Public properties

        /// <inheritdoc />
        public int Id { get; set; }

        /// <inheritdoc />
        public Pointer.PointerType Type { get; set; }

        /// <inheritdoc />
        public IInputSource InputSource { get; set; }

        /// <inheritdoc />
        public Vector2 Position { get; set; }

        /// <inheritdoc />
        public uint Flags { get; set; }

        #endregion

        #region Constructors

        public FakePointer(Vector2 position) : this()
        {
            Position = position;
        }

        public FakePointer()
        {
            Id = Pointer.INVALID_POINTER;
            Type = Pointer.PointerType.Unknown;
            Flags = Pointer.FLAG_ARTIFICIAL;
        }

        #endregion

        #region Public methods

        /// <inheritdoc />
        public HitData GetOverData(bool forceRecalculate = false)
        {
            HitData overData;
            TouchManagerInstance.Instance.INTERNAL_GetHitTarget(this, out overData);
            return overData;
        }

        #endregion
    }
}