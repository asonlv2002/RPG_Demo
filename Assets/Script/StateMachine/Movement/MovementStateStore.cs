namespace StateContents
{
    internal class MovementStateStore :StateStore
    {
        public BaseState Movement {get; private set;}

        public BaseState Grounded {get; private set;}

        public BaseState Idle {get; private set;}

        public BaseState Move {get; private set;}

        public BaseState Run {get; private set;}

        public BaseState Sprint {get; private set;}

        public BaseState Airborne {get; private set;}

        public BaseState JumpRise {get; private set;}

        public BaseState JumpFall {get; private set;}

        public BaseState Fall {get; private set;}

        public BaseState SprintToIdle {get; private set;}

        public BaseState StopOnGround {get; private set;}
        public BaseState AttackState {get; private set;}
        public BaseState Equip { get; private set;}
        public MovementStateStore(StateCore stateContext) : base(stateContext)
        {

        }
        protected override void CreateStateContain()
        {
            Movement = new PlayerMovementState(_stateContent, this);
            Grounded = new PlayerGroundedState(_stateContent, this);
            Airborne = new PlayerAirborneState(_stateContent, this);

            Move = new PlayerMoveState(_stateContent, this);
            Idle = new PlayerIdleState(_stateContent, this);

            JumpRise = new PlayerJumpRiseState(_stateContent, this);
            JumpFall = new PlayerJumpFallState(_stateContent, this);

            Fall = new PlayerFallState(_stateContent, this);

            Equip = new EquipWeapon(_stateContent, this);

        }

        public void AddAttackGroup(BaseState attackState)
        {
            AttackState = attackState;
        }
    }
}
